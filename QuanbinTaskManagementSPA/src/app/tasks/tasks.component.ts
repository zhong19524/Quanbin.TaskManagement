import { Component, ElementRef, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { ModalService } from '../core/services/modal.service';
import { TaskService } from '../core/services/task.service';
import { Tasks } from '../shared/models/task';
import { TasksCreate } from '../shared/models/taskCreate';
import { TasksUpdate } from '../shared/models/taskUpdate';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {

  @ViewChild('Taskform', { read: TemplateRef }) Taskform:ElementRef<any> | undefined;
  @ViewChild('Updateform', { read: TemplateRef }) Updateform:ElementRef<any> | undefined;
  @ViewChild('Deleteform', { read: TemplateRef }) Deleteform:ElementRef<any> | undefined;

  info:any;
  taskinfo:TasksCreate ={
    userId: 0,
    title: '',
    description: '',
    dueDate: new Date(),
    priority: '',
    remarks: ''
  }

  taskupdateinfo:TasksUpdate ={
    id :0,
    userId: 0,
    title: '',
    description: '',
    dueDate: new Date(),
    priority: '',
    remarks: ''
  }
  invalid!: boolean;
  deleteid=0;
  tasks!:Tasks[];
  constructor(private taskService:TaskService,

    private modalService:ModalService) { }

  ngOnInit(): void {
    this.taskService.getAllTasks().subscribe(
      t =>{
        this.tasks = t;
        console.log(this.tasks);
      }
    )
  }
  
  
  
  CreateTask(){
    this.modalService.open(this.Taskform);
  }

  onSubmit() {
    console.log(this.taskinfo);
    this.taskService.createTask(this.taskinfo)
      .subscribe((result) => {
        if (result) {
          this.ngOnInit(); //reload the table
          this.modalService.dismiss(); //dismiss the modal
          }
          else {
            this.invalid = true;
          }
        }, (err: any) => {
          this.invalid= true,
            console.log(err);
        })
  }

  UpdateTask(){
    this.modalService.open(this.Updateform);
  }

  onUpdate(){
    //var date = this.taskupdateinfo.dueDate.toJSON;
    //this.taskupdateinfo.dueDate = date;
    this.taskService.updateTask(this.taskupdateinfo)
      .subscribe((result) => {
        if (result) {
          this.ngOnInit(); //reload the table
          this.modalService.dismiss(); //dismiss the modal
          }
          else {
            this.invalid = true;
          }
        }, (err: any) => {
          this.invalid= true,
            console.log(err);
        })
  }

  DeleteTask(){
    //this.deleteid = id;
    this.modalService.open(this.Deleteform);
  }

  onDelete(){
    this.taskService.deleteTask(this.deleteid)
      .subscribe((result) => {
        if (result) {
          this.ngOnInit(); //reload the table
          this.modalService.dismiss(); //dismiss the modal
          }
          else {
            this.invalid = true;
          }
        }, (err: any) => {
          this.invalid= true,
            console.log(err);
        })
  }
}
