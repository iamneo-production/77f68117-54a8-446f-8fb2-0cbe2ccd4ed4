import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from 'rxjs/operators';
@Injectable({
    providedIn : 'root'
})
export class adminservice {
    constructor(private http : HttpClient){}

 getdata(){
        return this.http.get<any>('https://8080-dbbffecaaccbbacaddcceebceaacefafebd.project.examly.io/api/LoanApplication/GetAllLoans').pipe(map((res: any)=>{
            return res;
        }))
    }
}