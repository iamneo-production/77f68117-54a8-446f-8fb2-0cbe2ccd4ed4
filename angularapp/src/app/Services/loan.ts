export class laon{
      loanType : string;
     ApplicantName : string;
     ApplicantAddress : string;
     ApplicantMobile: string;
     ApplicantEmail :string;
     ApplicantAdhaar :string;
     ApplicantPan :string;
     ApplicantSalary :string;
     LoanAmountRequired : string;
     LoanRepaymentMonths : string;

     constructor(loanType : string,ApplicantName : string,ApplicantAddress : string,ApplicantMobile: string,ApplicantEmail :string, ApplicantAdhaar :string,ApplicantPan :string,ApplicantSalary :string,LoanAmountRequired : string,LoanRepaymentMonths : string)
     {
         this.loanType =loanType;
        this.ApplicantName=ApplicantName;
        this.ApplicantAddress=ApplicantAddress;
        this.ApplicantMobile=ApplicantMobile;
        this.ApplicantEmail=ApplicantEmail;
        this.ApplicantAdhaar=ApplicantAdhaar;
        this.ApplicantPan=ApplicantPan;
        this.ApplicantSalary=ApplicantSalary;
        this.LoanAmountRequired=LoanAmountRequired;
        this.LoanRepaymentMonths=LoanRepaymentMonths;
     }



}