import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoanDetailsComponent } from './loan-details/loan-details.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminnavComponent } from './adminnav/adminnav.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { LoanApplicationComponent } from './loan-application/loan-application.component';
import { FileUploadComponent } from './file-upload/file-upload.component';
import { AuthGuard } from './Services/auth.guard';




  const routes: Routes = [{
    path : 'loanapplicant/fileupload',
    component : FileUploadComponent
  },
  {
    path : 'loanapplicant',
    component : LoanApplicationComponent
  },
  {
    path: 'registration',
    component : RegisterComponent
  },
  {
    path : '',
    component : LoginComponent
  },
  {
    path : 'admin',
    component : AdminHomeComponent,
    // canActivate: [AuthGuard]
  },{
    path : 'admin/loandetails'
    , component:LoanDetailsComponent
  },{
    path : 'nav',
    component : AdminnavComponent
  },{
    path :'admin/loandetails/admin',
    component : AdminHomeComponent
  },{
    path : 'admin/loandetails/admin/loandetails',
    component : LoanDetailsComponent
  }
  ];
  
  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
    providers : [AuthGuard]
  })
  
  export class AppRoutingModule{}
