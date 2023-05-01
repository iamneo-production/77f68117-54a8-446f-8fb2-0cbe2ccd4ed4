import { Component } from '@angular/core';
import { LoginService } from '../Services/loginservice';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';


export class LoginModel {
  email !: string;
  password !: string;
}


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  login: LoginModel = new LoginModel();
  constructor(private loginservice: LoginService,private router:Router, private toastr : ToastrService) { }
  onSubmit(userForm: NgForm) {
    if(!userForm.valid)
    {
      alert("enter valid email address");
    }
    if (userForm.valid) {

      console.log(userForm.value);
      this.loginservice.Create(userForm.value).subscribe(res => {
       // console.log(res);
        var str= JSON.stringify(res)
       // console.log(str);
        var r= JSON.parse(str)
        if(r.errorMessage=='No user found with username'){
          alert("no such user found");
          userForm.resetForm();
        }
        else{
         var role= this.loginservice.settoken(r.message)
          //alert("login successful");
           role= role.toLowerCase();
         if(role == "admin"){
          this.router.navigateByUrl('admin');
          this.toastr.success("Welcome Admin");
         }
         else{
          this.router.navigateByUrl('loanapplicant');
          this.toastr.success("Welcome")
         }
          userForm.resetForm();
        }
       
        
        
      });

    }
  }
}
