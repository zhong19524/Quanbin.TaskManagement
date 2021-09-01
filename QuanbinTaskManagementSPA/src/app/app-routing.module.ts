import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TasksComponent } from './tasks/tasks.component';
import { TaskshistoryComponent } from './taskshistory/taskshistory.component';
import { UsersComponent } from './users/users.component';
const routes: Routes = [
  {path:"", component:HomeComponent},
  {path:"users/:id", component:UsersComponent},
  {path:"tasks",component:TasksComponent},
  {path:"taskshistories", component:TaskshistoryComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
