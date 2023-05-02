import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs";
@Injectable({
    providedIn : 'root'
})
export class adminservice {
    constructor(private http : HttpClient){}

 getdata(){
        return this.http.get<any>('https://localhost:44392/api/LoanApplication/GetAllLoans').pipe(map((res: any)=>{
            return res;
        }))
    }
}