import { Component, OnInit } from '@angular/core';
import { loanservices } from '../Services/loan-service';
import { adminservice } from '../Services/adminservice';

@Component({
  selector: 'app-loan-details',
  templateUrl: './loan-details.component.html',
  styleUrls: ['./loan-details.component.css']
})
export class LoanDetailsComponent implements OnInit {

  public newData: any[] = [];
  constructor(private adminservices: adminservice) { }

  ngOnInit(): void {
    this.adminservices.getdata().subscribe((res: any) => {
      var js = JSON.stringify(res)
      var jp = JSON.parse(js)
      console.log(jp);

      this.newData = jp.response.loans.result;

    })
  }
}