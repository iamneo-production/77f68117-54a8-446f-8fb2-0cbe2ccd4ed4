﻿using dotnetapp.Core.Interfaces;
using dotnetapp.Models;
using dotnetapp.Controllers;
using dotnetapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Data;


namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication iauthentication;
        private readonly ILogger<AuthenticationController> logger;


        public AuthenticationController(IAuthentication iauthentication, ILogger<AuthenticationController> logger)
        {
            this.iauthentication = iauthentication;
            this.logger = logger;
        }





        [HttpPost]
        [Route("Token")]
        [AllowAnonymous]
        public ResponseModel GenerateToken([FromBody] Login loginmodel)
        {
            ResponseModel response = null;
            try
            {
                logger.LogInformation("Checking whether the User Email and Password is available in the database");
                if (loginmodel != null)
                {
                    if (!loginmodel.Email.IsNullOrEmpty() && !loginmodel.Password.IsNullOrEmpty())
                    {
                        response = iauthentication.GenerateToken(loginmodel);
                        return response;
                    }
                    else
                    {
                        response = new ResponseModel();
                        response.Message = "Username & password is required";
                        response.Status = false;
                        return response;
                    }
                }
                else
                {
                    response = new ResponseModel();
                    response.Message = "Send proper data in request";
                    response.Status = false;
                    return response;

                }

            }
            catch (System.Exception ex)
            {
                logger.LogError($"An Exception has occcured while running program with message {ex.Message}");
                response = new ResponseModel();
                response.Message = " Opps! Something went wrong";
                response.ErrorMessage = ex.Message;
                response.Status = false;
                return response;


            }
        }



    }
}