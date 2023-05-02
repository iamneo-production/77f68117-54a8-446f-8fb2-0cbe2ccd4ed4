import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
// import { NgxFileDropModule } from 'ngx-file-drop';
// import { FileUploadComponent } from './file-upload/file-upload.component';
// import { LoanApplicationComponent } from './loan-application/loan-application.component';
import { ToastrModule } from 'ngx-toastr';
// import { LoginComponent } from './login/login.component';
// import { RegisterComponent } from './register/register.component';
// import { AdminHomeComponent } from './admin-home/admin-home.component';
import { LoanDetailsComponent } from './loan-details/loan-details.component';
import { AdminnavComponent } from './adminnav/adminnav.component';
import { CustomernavComponent } from './customernav/customernav.component';


@NgModule({
  declarations: [
    AppComponent,
    // FileUploadComponent,
    // LoanApplicationComponent,
    // LoginComponent,
    // RegisterComponent,
    // AdminHomeComponent,
    LoanDetailsComponent,
    AdminnavComponent,
    CustomernavComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
   

    // NgxFileDropModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
