using dotnetapp.Core.Interface;
using dotnetapp.Models;
using dotnetapp.Context;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace dotnetapp.Core
{
    public class AuthenticationCore : IAuthentication
    {
        private readonly EducationLoanContext educationLoanContext;
        private readonly IConfiguration configuration;

        public AuthenticationCore(EducationLoanContext educationLoanContext, IConfiguration configuration)
        {
            this.educationLoanContext = educationLoanContext;
            this.configuration = configuration;
        }

        public ResponseModel GenerateToken(Login loginModel)
        {
            try
            { 
                var userExist = educationLoanContext.userModels.FirstOrDefault(x => x.Email == loginModel.Email.ToLower() && x.Password.ToLower() == loginModel.Password);
                if (userExist != null)
                {
                    var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Key"]));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var claims = new[]
                    {
                         new Claim(ClaimTypes.Name, loginModel.Email),
                        //new Clain("role" , role)
                    };

                    // var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"], claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);
                    var token = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);

                    var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);

                    ResponseModel responseModel = new ResponseModel();
                    responseModel.Message = generatedToken.ToString();
                    responseModel.Status = true;
                    return responseModel;
                }

                ResponseModel response = new ResponseModel();
                response.Message = $"NO user found with the {loginModel.Email}";
                response.Status = true;
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<string> welcome()
        {
            try
            {
                return "Welcome to my code.";
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}



