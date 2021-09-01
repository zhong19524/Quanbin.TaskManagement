import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Users } from 'src/app/shared/models/user';
import { UsersCreate } from 'src/app/shared/models/userCreate';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient) { }

  getAllUsers():Observable<Users[]>{
    return this.http.get(`${environment.apiUrl}`+'User').pipe(
      map(resp => resp as Users[])
    )
  }

  createUser(userCreate:UsersCreate):Observable<boolean>{
    return this.http.post(`${environment.apiUrl}`+'User/Create',userCreate).pipe(
      map((response:any) =>{
        if (response){
          return true;
        }
        return false
      })
    )}

  updateUser(userinfo:UsersCreate):Observable<boolean>{
    return this.http.put(`${environment.apiUrl}`+'User/Update',userinfo).pipe(
      map((response:any) =>{
        if (response){
          return true;
        }
        return false
      })
    )}
  
  deleteUser(id:number):Observable<boolean>{
    return this.http.delete(`${environment.apiUrl}`+'User/Delete/'+id).pipe(
      map((response:any) =>{
        if (response){
          return true;
        }
        return false
      })
    )}
}
