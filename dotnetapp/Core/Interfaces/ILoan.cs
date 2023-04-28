using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace dotnetapp.Core.Interfaces
{
    public interface ILoan
    {
        List<LoanApplicantModel> Getall();

        LoanApplicantModel GetById(int id);

        string CreateApplication(LoanApplicantModel loanapplicantmodel);

        string UpdateApplication(LoanApplicantModel loanapplicantmodel);

        string DeleteApplication(int id);
    }
}
