import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegisterService } from '../Services/register.service';
import { ToastrService } from 'ngx-toastr';


export class RegisterModel {
  Email!: string;
  Password!: string;
  UserName!: string;
  MobileNumber: any;
  UserRole!: string;
}

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent  implements OnInit{
  registerForm!: FormGroup;


  constructor(private formBuilder: FormBuilder, public registerservice: RegisterService, private toastr : ToastrService) { }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      UserName: ['', Validators.required],
      Email: ['', [Validators.required ]],
      Password: ['', [Validators.required]],
      MobileNumber: ['', Validators.required],
      UserRole: ['', Validators.required]

    });
  }
  onSubmit(): void {
    if (this.registerForm.valid) {
      this.registerservice.Create(this.registerForm.value).subscribe(res=>{console.log(res)}); 
      this.toastr.success("Registration successfully!!");
      this.registerForm.reset(); 
    } 
    else {
     // alert('Form should not be null');
      this.toastr.error("Registration failed");
    }
  }
    
}
