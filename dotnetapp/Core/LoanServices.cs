using dotnetapp.Core.Interfaces;
using dotnetapp.Context;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using System.Linq;
namespace dotnetapp.Core
{
    public class LoanServices : ILoan
    {
        private readonly EducationLoanContext educationLoanContext;

        public LoanServices(EducationLoanContext educationLoanContext)
        {
            this.educationLoanContext = educationLoanContext;   
        }
       

        public LoanApplicantModel GetById(int id)
        {
            throw new NotImplementedException();
        }
        public string CreateApplication(LoanApplicantModel loanapplicantmodel)
        {
            try
            {
                if(loanapplicantmodel != null)
                {
                    educationLoanContext.loansApplicantModels.Add(loanapplicantmodel);
                    educationLoanContext.SaveChanges();
                    return "Applied For Loan Successfully";
                }
                return "something went wronng";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

       
        public string UpdateApplication(LoanApplicantModel loanapplicantmodel)
        {
            try
            {
                if(loanapplicantmodel != null)
                {
                   var loanId = educationLoanContext.loansApplicantModels.Find(loanapplicantmodel.LoanId);

                    if(loanId != null) 
                    { 
                        loanId.ApplicantName=loanapplicantmodel.ApplicantName;
                        loanId.ApplicantEmail=loanapplicantmodel.ApplicantEmail;
                        loanId.ApplicantAdhaar = loanapplicantmodel.ApplicantAddress;
                        loanId.ApplicantMobile= loanapplicantmodel.ApplicantMobile;
                        loanId.ApplicantSalary=loanapplicantmodel.ApplicantSalary;
                        loanId.ApplicantPan=loanapplicantmodel.ApplicantPan;
                        loanId.LoanAmountRequired=loanapplicantmodel.LoanAmountRequired;
                        loanId.LoanRepaymentMonths=loanapplicantmodel.LoanRepaymentMonths;
                        loanId.LoanType=loanapplicantmodel.LoanType;

                        educationLoanContext.loansApplicantModels.Update(loanId);
                        educationLoanContext.SaveChanges();
                        return "Updated Successfully";
                    }
                    return "Updation not completed!!!!!!!!!!";


                }
                return "empty";
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<LoanApplicantModel> Getall()
        {
            try
            {
                var allloans = educationLoanContext.loansApplicantModels?.ToList();
                if (allloans != null)
                {
                    return allloans;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string DeleteApplication(int id)
        {
            try
            {
                var response = educationLoanContext.loansApplicantModels.Find(id);
                if(response != null)
                {
                    educationLoanContext.loansApplicantModels.Remove(response);
                    educationLoanContext.SaveChanges();
                    return $"Deleted successfully{response.ApplicantName}";
                }
                return "oopps something is wrong";
            }
            catch (Exception)
            {

                throw;
            }
        }

       
    }
}
