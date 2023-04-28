using dotnetapp.Core.Interfaces;
using dotnetapp.Models;
using dotnetapp.Context;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser iuser;

        public UserController(IUser iuser)
        {
            this.iuser = iuser;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<ResponseModel>> Create(UserModel userModel)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                var res = iuser.AddUSer(userModel);
                if(res != null)
                {
                    responseModel = new ResponseModel();
                    responseModel.Response = new
                    {
                        userModel.UserRole,
                        userModel.UserName,
                        userModel.Email,
                        userModel.Password,
                        message = "Registraion Successfull !"
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
                    responseModel.ErrorMessage = "Error occured while registering";
                    return responseModel;
                }
                
            }
            catch (Exception) 
            {
                responseModel = new ResponseModel();
                responseModel.Status = false;
                responseModel.Message = "Failure";
                responseModel.ErrorMessage = "Something went wrong registering !";

                throw;
            }
        }


        [HttpGet]
        [Route("Getall")]
        public async Task<ActionResult<ResponseModel>> GetAll()
        {
            ResponseModel responseModel = null;
            try
            {
                var allusers = await iuser.GetAllUser();
                if (allusers != null)
                {
                    responseModel = new ResponseModel();
                    responseModel.Response = new
                    {
                        users = allusers
                    };
                    responseModel.Status = true;
                    responseModel.Message = "Success";
                    return responseModel;
                }
                else
                {
                    responseModel= new ResponseModel();
                    responseModel.Status = false;
                    responseModel.Message = "Failure";
                    responseModel.ErrorMessage = "Getting All user went wrong!";
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

        [HttpPost]
        [Route("Update")]
        public async Task<ActionResult<ResponseModel>> Update(int id,UserModel userModel)
        {
            ResponseModel responseModel = null;
            try
            {
                var response = await iuser.UpdateUser(id,userModel);
                if(response != null)
                {
                    responseModel = new ResponseModel();
                    responseModel.Response = new
                    {
                        userModel.UserName,
                        userModel.Email,
                        userModel.UserRole,
                        message = "Updated successfully !!"
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
                    return responseModel;
                    
                }
            }
            catch (Exception)
            {
                responseModel = new ResponseModel();
                responseModel.Status = false;
                responseModel.Message = "Failure";
                responseModel.ErrorMessage = "Something went wrong";

                throw;
            }
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<ResponseModel>> GetById(int id)
        {
            ResponseModel responseModel = null;
            try
            {
                var responsebyid = await iuser.GetUserById(id);
                if(responsebyid != null)
                {
                    responseModel = new ResponseModel();
                    responseModel.Response = new
                    {
                       responsebyid.UserName,
                       responsebyid.Email,
                       responsebyid.UserRole,
                       responsebyid.MobileNumber
                    };
                    responseModel.Status= true;
                    responseModel.Message = "Success";
                    return responseModel;
                }
                else
                {
                    responseModel = new ResponseModel();
                    responseModel.Status = false;
                    responseModel.Message = "Failure";
                    responseModel.ErrorMessage = "Id is invalid";
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

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<ResponseModel>> Delete(int id)
        {
            ResponseModel responseModel = null;

            try
            {
                var deleteuser = await iuser.DeleteUser(id);
                if(deleteuser != null)
                {
                    responseModel = new ResponseModel();
                    responseModel.Response = new
                    {
                        deleteuser.UserName,
                        deleteuser.Email,
                        deleteuser.UserRole,
                        deleteuser.MobileNumber,
                        message = "Deleted Successfully"

                    };
                    responseModel.Status= true;
                    responseModel.Message = "Success";
                    return responseModel;
                }
                else
                {
                    responseModel = new ResponseModel();
                    responseModel.Status = true;
                    responseModel.Message = "failure";
                    responseModel.ErrorMessage = "Invalid id";
                    return responseModel;
                }

            }
            catch (Exception ex)
            {

                responseModel = new ResponseModel();
                responseModel.Status = true;
                responseModel.Message = "failure";
                responseModel.ErrorMessage = ex.Message;
                return responseModel;
            }
        }
    }
}
