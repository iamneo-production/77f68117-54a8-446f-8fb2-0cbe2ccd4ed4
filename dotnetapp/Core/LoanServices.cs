using dotnetapp.Core.Interfaces;
using dotnetapp.Context;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Core
{
    public class LoanServices : ILoan
    {
        private readonly EducationLoanContext educationLoanContext;

        public LoanServices(EducationLoanContext educationLoanContext)
        {
            this.educationLoanContext = educationLoanContext;   
        }
       

        public async Task<LoanApplicantModel> GetById(int id)
        {
            try
            {
                var response = await educationLoanContext.loansApplicantModels.FindAsync(id);
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<LoanApplicantModel> CreateApplication(LoanApplicantModel loanapplicantmodel)
        {
            try
            {
                if(loanapplicantmodel != null)
                {
                   var response = await educationLoanContext.loansApplicantModels.AddAsync(loanapplicantmodel);
                   await educationLoanContext.SaveChangesAsync();
                    return loanapplicantmodel;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        public async Task<LoanApplicantModel> UpdateApplication(LoanApplicantModel loanapplicantmodel)
        {
            try
            {
                if(loanapplicantmodel != null)
                {
                   var loanId = await educationLoanContext.loansApplicantModels.FindAsync(loanapplicantmodel.LoanId);

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
                        await educationLoanContext.SaveChangesAsync();
                        return loanId;
                    }

                    return null;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<LoanApplicantModel>> Getall()
        {
            try
            {
                var allloans = educationLoanContext.loansApplicantModels.ToList();
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

        public async Task<LoanApplicantModel> DeleteApplication(int id)
        {
            try
            {
                var response = await educationLoanContext.loansApplicantModels.FindAsync(id);
                if(response != null)
                {
                    educationLoanContext.loansApplicantModels.Remove(response);
                    educationLoanContext.SaveChanges();
                    return response;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<LoanApplicantModel> UpdateLoanStatus(int id,string status)
        {
            try
            {
                var loan = await educationLoanContext.loansApplicantModels.FindAsync(id);
                if(loan == null)
                {
                    return null;
                }

                loan.Status = status;   
                await educationLoanContext.SaveChangesAsync();
                return loan;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
