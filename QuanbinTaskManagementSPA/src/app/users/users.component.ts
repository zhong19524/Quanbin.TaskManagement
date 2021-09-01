import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { TaskService } from '../core/services/task.service';
import { ActivatedRoute } from '@angular/router';
import { Tasks } from '../shared/models/task';
import { TasksHistory } from '../shared/models/taskshistory';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  tasks!:Tasks[];
  tasksHistories!:TasksHistory[];
  constructor(private taskService:TaskService,
              private route:ActivatedRoute
              ) { }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.taskService.getTasks(id).subscribe(
      t =>{
        this.tasks = t;
        console.log(this.tasks);
      }
    )
    this.taskService.getTasksHistories(id).subscribe(
      th =>{
        this.tasksHistories = th;
        console.log(this.tasksHistories);
      }
    )
  }
  
}




