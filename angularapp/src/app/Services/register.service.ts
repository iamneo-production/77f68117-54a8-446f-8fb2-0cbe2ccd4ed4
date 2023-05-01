import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RegisterComponent } from '../register/register.component';


const URL:any="https://8080-dbbffecaaccbbacaddcceebceaacefafebd.project.examly.io/api/User/Register";
@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  
  constructor(private http:HttpClient) { }
  Create(data:RegisterComponent) : Observable<any>
  {
    return this.http.post<RegisterComponent>(URL,data);
  }
  
}
