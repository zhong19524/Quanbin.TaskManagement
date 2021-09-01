import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { UserCardComponent } from './shared/components/user-card/user-card.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { HeaderComponent } from './core/layout/header/header.component';
import { UsersComponent } from './users/users.component';
import { TasksComponent } from './tasks/tasks.component';
import { TaskshistoryComponent } from './taskshistory/taskshistory.component';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    UserCardComponent,
    HeaderComponent,
    UsersComponent,
    TasksComponent,
    TaskshistoryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
