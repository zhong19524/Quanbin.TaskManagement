import { Component, ElementRef, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormGroup, NgForm } from '@angular/forms';
import { ModalService } from '../core/services/modal.service';
import { TaskService } from '../core/services/task.service';
import { UserService } from '../core/services/user.service';
import { Tasks } from '../shared/models/task';
import { Users } from '../shared/models/user';
import { UsersCreate } from '../shared/models/userCreate';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  
  @ViewChild('Userform', { read: TemplateRef }) Userform:ElementRef<any> | undefined;
  @ViewChild('Updateform', { read: TemplateRef }) Updateform:ElementRef<any> | undefined;
  @ViewChild('Deleteform', { read: TemplateRef }) Deleteform:ElementRef<any> | undefined;

  info:any;
  userinfo:UsersCreate ={
    email: '',
    password: '',
    fullname: '',
    mobileno: ''
  }
  invalid!: boolean;
  deleteid=0;
  //tasks!:Tasks[];
  users!:Users[];
  constructor(private userService:UserService,
              private modalService:ModalService
              ) { }

  ngOnInit(): void {
    this.userService.getAllUsers().subscribe(
      u=>{
        this.users = u;
        console.log('inside home component');
        console.log(this.users);
    }) 
  }

  CreateUser(){
    this.modalService.open(this.Userform);
  }

  onSubmit() {
    this.userService.createUser(this.userinfo)
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

  UpdateUser(){
    this.modalService.open(this.Updateform);
  }

  onUpdate(){
    this.userService.updateUser(this.userinfo)
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

  DeleteUser(){
    //this.deleteid = id;
    this.modalService.open(this.Deleteform);
  }

  onDelete(){
    this.userService.deleteUser(this.deleteid)
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

