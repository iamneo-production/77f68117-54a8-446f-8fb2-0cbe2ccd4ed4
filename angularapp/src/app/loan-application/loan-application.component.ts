import { Component, OnInit } from '@angular/core';
import { loanservices } from '../Services/loan-service';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-loan-application',
  templateUrl: './loan-application.component.html',
  styleUrls: ['./loan-application.component.css']
})
export class LoanApplicationComponent {
  applicant = {

    loanType: '',

    ApplicantName: '',

    ApplicantAddress: '',

    ApplicantEmail: '',

    ApplicantMobile: '',

    ApplicantAdhaar: '',

    ApplicantPan: '',

    ApplicantSalary: '',

    LoanAmountRequired: '',

    LoanRepaymentMonths: ''

  };
  constructor(private http: HttpClient, private toastr: ToastrService) { }

  onSubmit() {

    this.http.post('https://8080-dbbffecaaccbbacaddcceebceaacefafebd.project.examly.io/api/LoanApplication', this.applicant).subscribe(response => {

      console.log('Application submitted !!', response);
      this.toastr.success("Applied Successfully !")
    }, error => {
     console.log('Error while submitting !!');
      this.toastr.error("Applied failed !");
    });

  }

}