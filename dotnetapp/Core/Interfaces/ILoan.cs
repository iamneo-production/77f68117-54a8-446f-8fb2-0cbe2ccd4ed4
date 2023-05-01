using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnetapp.Core.Interfaces
{
    public interface ILoan
    {
        Task<List<LoanApplicantModel>> Getall();

        Task<LoanApplicantModel> GetById(int id);

        Task<LoanApplicantModel> CreateApplication(LoanApplicantModel loanapplicantmodel);

        Task<LoanApplicantModel> UpdateApplication(LoanApplicantModel loanapplicantmodel);

        Task<LoanApplicantModel> DeleteApplication(int id);

        Task<LoanApplicantModel> UpdateLoanStatus(int id,string status);
    }
}
