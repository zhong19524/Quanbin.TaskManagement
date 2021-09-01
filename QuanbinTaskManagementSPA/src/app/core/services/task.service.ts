import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Tasks } from 'src/app/shared/models/task';
import { TasksHistory } from 'src/app/shared/models/taskshistory';
import { HttpClient} from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { TasksCreate } from 'src/app/shared/models/taskCreate';
import { TasksHistoryCreate } from 'src/app/shared/models/taskshistoryCreate';
import { TasksHistoryUpdate } from 'src/app/shared/models/taskshistoryUpdate';
import { TasksUpdate } from 'src/app/shared/models/taskUpdate';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  constructor(private http:HttpClient) { }

  getTasks(id:number):Observable<Tasks[]>{
    return this.http.get(`${environment.apiUrl}`+"User/"+id+'/tasks').pipe(map(resp=>resp as Tasks[])
    )
  }

  getTasksHistories(id:number):Observable<TasksHistory[]>{
    return this.http.get(`${environment.apiUrl}`+"User/"+id+'/taskhistories').pipe(map(resp=>resp as TasksHistory[])
    )
  }

  getAllTasks():Observable<Tasks[]>{
    return this.http.get(`${environment.apiUrl}`+'Tasks').pipe(map(resp=>resp as Tasks[])
    )
  }

  getAllTasksHistories():Observable<TasksHistory[]>{
    return this.http.get(`${environment.apiUrl}`+'Taskshistory').pipe(map(resp=>resp as TasksHistory[])
    )
  }

  // Task CURD Operation
  createTask(taskCreate:TasksCreate):Observable<boolean>{
    return this.http.post(`${environment.apiUrl}`+'Tasks/Create',taskCreate).pipe(
      map((response:any) =>{
        if (response){
          return true;
        }
        return false
      })
    )}

  updateTask(taskinfo:TasksUpdate):Observable<boolean>{
    return this.http.put(`${environment.apiUrl}`+'Tasks/Update',taskinfo).pipe(
      map((response:any) =>{
        if (response){
          return true;
        }
        return false
      })
    )}
  
  deleteTask(id:number):Observable<boolean>{
    return this.http.delete(`${environment.apiUrl}`+'Tasks/Delete/'+id).pipe(
      map((response:any) =>{
        if (response){
          return true;
        }
        return false
      })
    )}
  
  //TaskHistory CRUD
  createTasksHistory(taskCreate:TasksHistoryCreate):Observable<boolean>{
    return this.http.post(`${environment.apiUrl}`+'TasksHistory/Create',taskCreate).pipe(
      map((response:any) =>{
        if (response){
          return true;
        }
        return false
      })
    )}

  updateTasksHistory(taskinfo:TasksHistoryUpdate):Observable<boolean>{
    return this.http.put(`${environment.apiUrl}`+'TasksHistory/Update',taskinfo).pipe(
      map((response:any) =>{
        if (response){
          return true;
        }
        return false
      })
    )}
  
  deleteTasksHistory(id:number):Observable<boolean>{
    return this.http.delete(`${environment.apiUrl}`+'TasksHistory/Delete/'+id).pipe(
      map((response:any) =>{
        if (response){
          return true;
        }
        return false
      })
    )}
  

}
