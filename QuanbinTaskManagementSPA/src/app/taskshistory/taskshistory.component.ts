import { Component, ElementRef, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { ModalService } from '../core/services/modal.service';
import { TaskService } from '../core/services/task.service';
import { TasksHistory } from '../shared/models/taskshistory';
import { TasksHistoryCreate } from '../shared/models/taskshistoryCreate';
import { TasksHistoryUpdate } from '../shared/models/taskshistoryUpdate';

@Component({
  selector: 'app-taskshistory',
  templateUrl: './taskshistory.component.html',
  styleUrls: ['./taskshistory.component.css']
})
export class TaskshistoryComponent implements OnInit {

  @ViewChild('Taskform', { read: TemplateRef }) Taskform:ElementRef<any> | undefined;
  @ViewChild('Updateform', { read: TemplateRef }) Updateform:ElementRef<any> | undefined;
  @ViewChild('Deleteform', { read: TemplateRef }) Deleteform:ElementRef<any> | undefined;

  info:any;
  taskinfo:TasksHistoryCreate ={
    userId: 0,
    title: '',
    description: '',
    dueDate: new Date(),
    completed: new Date(),
    remarks: ''
  }

  taskupdateinfo:TasksHistoryUpdate ={
    taskId:0,
    userId: 0,
    title: '',
    description: '',
    dueDate: new Date(),
    completed: new Date(),
    remarks: ''
  }
  invalid!: boolean;
  deleteid=0;

  tasksHistories!:TasksHistory[];
  constructor(private taskService:TaskService,
              private modalService:ModalService
              ) { }

  ngOnInit(): void {
    this.taskService.getAllTasksHistories().subscribe(
      t =>{
        this.tasksHistories = t;
        console.log(this.tasksHistories);
      }
    )
  }
  
  
  CreateTasksHistory(){
    this.modalService.open(this.Taskform);
  }

  onSubmit() {
    this.taskService.createTasksHistory(this.taskinfo)
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

  UpdateTasksHistory(){
    this.modalService.open(this.Updateform);
  }

  onUpdate(){
    //var date = this.taskupdateinfo.dueDate.toJSON;
    //this.taskupdateinfo.dueDate = date;
    this.taskService.updateTasksHistory(this.taskupdateinfo)
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

  DeleteTasksHistory(){
    //this.deleteid = id;
    this.modalService.open(this.Deleteform);
  }

  onDelete(){
    this.taskService.deleteTasksHistory(this.deleteid)
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
