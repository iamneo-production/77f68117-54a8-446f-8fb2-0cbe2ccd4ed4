import { Component, OnInit } from '@angular/core';
import { adminservice } from '../Services/adminservice';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.css']
})
export class AdminHomeComponent implements OnInit{

 public newData: any[] = [];

  constructor(private adminservice : adminservice, private http :HttpClient, private toastr : ToastrService){}

  ngOnInit() : void{
    this.adminservice.getdata().subscribe((res : any) => {
      var js=JSON.stringify(res)
      var jp = JSON.parse(js) 
      console.log(jp);
      
      this.newData= jp.response.loans.result;
    })
  }

  approveloan(id : number){
    const url = `https://8080-dbbffecaaccbbacaddcceebceaacefafebd.project.examly.io/api/LoanApplication/loans`;
    var body = "Approved";
    
    this.http.put(`${url}/${id}/${body}`,body).subscribe(response => {
      console.log(response);
      this.toastr.success("Loan Approved ❤")
      
    });
  }

  rejectloan(id : number){
    const url = `https://8080-dbbffecaaccbbacaddcceebceaacefafebd.project.examly.io/api/LoanApplication/loans`;
   
    var str = "Rejected"
   
    this.http.put(`${url}/${id}/${str}`,str).subscribe(response => {
      console.log(response);
      this.toastr.error("Loan Rejected")

    });
  }

}
