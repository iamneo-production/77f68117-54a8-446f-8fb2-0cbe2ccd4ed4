 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using dotnetapp.Context;
using dotnetapp.Models;
using dotnetapp.Core.Interfaces;
using dotnetapp.Models;
using Microsoft.Extensions.Logging;

namespace ApplicationLoan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanApplicationController : ControllerBase
    {
        private readonly ILoan iloan;
        private readonly ILogger<LoanApplicationController> ilogger;


        public LoanApplicationController(ILoan iloan, ILogger<LoanApplicationController> ilogger)
        {
            this.ilogger = ilogger;
            this.iloan = iloan;
        }

       // Get the all loan application details



        [HttpGet]
        [Route("GetAllLoans")]
        public async Task<ActionResult<ResponseModel>> GetLoansModels()
        {
            ResponseModel responseModel = null;
            try
            {
                ilogger.LogInformation("entering try block in getloans");
                var response = iloan.Getall();
                if (response != null)
                {
                    ilogger.LogInformation("returing response");
                    responseModel = new ResponseModel();
                    responseModel.Response = new
                    {
                        Loans = response
                    };
                    responseModel.Status = true;
                    responseModel.Message = "Success";
                    return responseModel;
                }
                else
                {
                    ilogger.LogError("entering else block");
                    responseModel = new ResponseModel();
                    responseModel.Status = false;
                    responseModel.Message = "Failure";
                    responseModel.ErrorMessage = "Error while fetching the list of loans";
                    return responseModel; 
                }

            }
            catch (Exception)
            {
                ilogger.LogError("entering catch getallloans block");
                responseModel = new ResponseModel();
                responseModel.Status = false;
                responseModel.Message = "Failure";
                responseModel.ErrorMessage = "Error while fetching the list of loans";
                throw;
            }
        }



        //get the loan details by the loanid

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel>> GetLoanApplicationModel(int id)
        {
            ResponseModel responseModel = null;

            try
            {

                ilogger.LogInformation("Entering try block getloanbyid");
                var loanApplicationModel =  await iloan.GetById(id);

                if (loanApplicationModel != null)
                {
                    ilogger.LogInformation("returning response block");
                    responseModel = new ResponseModel();
                    responseModel.Response = new
                    {
                        loanApplicationModel.ApplicantName,
                        loanApplicationModel.ApplicantAdhaar,
                        loanApplicationModel.ApplicantEmail,
                        loanApplicationModel.ApplicantAddress,
                        loanApplicationModel.ApplicantPan,
                        loanApplicationModel.ApplicantSalary,
                        loanApplicationModel.LoanAmountRequired,
                        loanApplicationModel.LoanType,
                        loanApplicationModel.LoanRepaymentMonths
                    };

                    responseModel.Status = true;
                    responseModel.Message = "Success";
                    ilogger.LogInformation("return responsemodel");
                    return responseModel;
                    
                }
                else
                {
                    responseModel = new ResponseModel();
                    responseModel.Status = false;
                    responseModel.Message = "Failure";
                    responseModel.ErrorMessage = "Invalid Id";
                    return responseModel;
                }

            }catch (Exception ex)
            {
                responseModel = new ResponseModel();
                responseModel.Status =false;
                responseModel.Message = "Failure";
                responseModel.ErrorMessage = ex.Message;
                return responseModel;
            }

            
        }



        //update the loan application details

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseModel>> PutLoanApplicationModel(LoanApplicantModel loanApplicantModel)
        {
            ResponseModel responseModel = null;
            try
            {
                var response = await iloan.UpdateApplication(loanApplicantModel);
                if (response != null)
                {
                    responseModel = new ResponseModel();
                    responseModel.Response = new
                    {
                        loanApplicantModel.ApplicantName,
                        loanApplicantModel.ApplicantSalary,
                        loanApplicantModel.ApplicantEmail,
                        loanApplicantModel.ApplicantAdhaar,
                        loanApplicantModel.ApplicantPan,
                        loanApplicantModel.ApplicantMobile,
                        loanApplicantModel.LoanAmountRequired,
                        loanApplicantModel.LoanRepaymentMonths,
                        loanApplicantModel.LoanType
                    };
                    responseModel.Status=true;
                    responseModel.Message = "Success";
                   
                    return responseModel;
                }
                else
                {
                    responseModel = new ResponseModel();
                    responseModel.Status = true;
                    responseModel.Message = "Success";
                    responseModel.ErrorMessage = "somthing went Wrong!";
                    return responseModel;
                }
            }
            catch (Exception ex)
            {

                responseModel = new ResponseModel();
                responseModel.Status = true;
                responseModel.Message = "Success";
                responseModel.ErrorMessage = ex.Message;
                return responseModel;
            }
        }



        ////apply for the loan
        [HttpPost]
        public async Task<ActionResult<ResponseModel>> PostLoanApplicationModel(LoanApplicantModel loanApplicationModel)
        {
            ResponseModel responseModel = null;
            try
            {

                var response = await iloan.CreateApplication(loanApplicationModel);
                if(response != null)
                {
                    responseModel = new ResponseModel();
                    responseModel.Response = new
                    {
                        loanApplicationModel.LoanId,
                        loanApplicationModel.ApplicantName,
                        loanApplicationModel.ApplicantEmail,
                        loanApplicationModel.ApplicantAdhaar,
                        loanApplicationModel.ApplicantPan,
                        loanApplicationModel.ApplicantMobile,
                        loanApplicationModel.ApplicantAddress,
                        loanApplicationModel.ApplicantSalary,
                        loanApplicationModel.LoanAmountRequired,
                        loanApplicationModel.LoanRepaymentMonths,
                        loanApplicationModel.LoanType,
                        message = "Created Successfully !!",
                    };
                    responseModel.Status = true;
                    responseModel.Message = "Success";
                    return responseModel;
                }
                else
                {
                    responseModel = new ResponseModel();
                    responseModel.Status= false;
                    responseModel.Message = "failure";
                    responseModel.ErrorMessage = "somethig went wrong";
                    return responseModel;
                }
                      
            }
            catch (Exception ex)
            {
                responseModel = new ResponseModel();
                responseModel.Status = false;
                responseModel.Message = "failure";
                responseModel.ErrorMessage = ex.Message;
                return responseModel;
            }
        }


        ////delete the loan application

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel>> DeleteLoanApplicationModel(int id)
        {
            ResponseModel responseModel = null;
            try
            {
                var response = await iloan.DeleteApplication(id);
                if(response != null)
                {
                    responseModel = new ResponseModel();
                    responseModel.Response = new
                    {
                        loanApplication = response,
                        message = "Deleted Successfully !!"
                    };
                    responseModel.Status = true;
                    responseModel.Message = "Success";
                    return responseModel;
                }
                else
                {
                    responseModel = new ResponseModel();
                    responseModel.Status= false;
                    responseModel.Message = "Failure";
                    responseModel.ErrorMessage = "somthing went wrong";
                    return responseModel;
                }
            }
            catch (Exception ex)
            {

                responseModel = new ResponseModel();
                responseModel.Status = false;
                responseModel.Message = "Failure";
                responseModel.ErrorMessage = ex.Message;
                return responseModel;
            }
        }

        [HttpPut("loans/{id}/{Status}")]
       // [Consumes("application/json")]
        public async Task<ActionResult<ResponseModel>> UpdateLoanStatus(int id,string Status)
        {
            ResponseModel responseModel = null; 
            try
            {
                var stat = await iloan.UpdateLoanStatus(id, Status);
                if(stat != null)
                {
                    responseModel = new ResponseModel();
                    responseModel.Response = new
                    {
                        Status = stat
                    };
                    responseModel.Status = true;
                    responseModel.Message = "Success";
                    return responseModel;

                }
                else
                {
                    responseModel = new ResponseModel();
                    responseModel.Status = false;
                    responseModel.Message = "Failure";
                    responseModel.ErrorMessage = "status updating went wrong";
                    return responseModel;
                }
            }
            catch (Exception ex)
            {

                responseModel = new ResponseModel();
                responseModel.Status = false;
                responseModel.Message = "Failure";
                responseModel.ErrorMessage = ex.Message;
                return responseModel;
            }
        }


    }
}