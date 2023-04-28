using dotnetapp.Core.Interfaces;
using dotnetapp.Context;
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace dotnetapp.Core
{
    public class UserServices : IUser
    {
        private readonly EducationLoanContext educationLoanContext;
        private readonly ILogger<UserServices> logger;

        public UserServices(EducationLoanContext educationLoanContext, ILogger<UserServices> logger)
        {
            this.educationLoanContext = educationLoanContext;
            this.logger = logger;
        }

        public async Task<UserModel> AddUSer(UserModel userModel)
        {
            try
            {
                logger.LogInformation("Calling databse to add the User");
                if(userModel != null) 
                {
                    await educationLoanContext.userModels.AddAsync(userModel);
                    await educationLoanContext.SaveChangesAsync();
                    return userModel;
                }
                return null;
            }
            catch (Exception ex)
            {
                logger.LogError("Error occured while adding user data to the database", ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserModel> DeleteUser(int id)
        {
            try
            {
                logger.LogInformation("Calling database to Delete the User");
                var response = await educationLoanContext.userModels.FindAsync(id);
                if (response != null)
                {
                    educationLoanContext.userModels.Remove(response);
                    await educationLoanContext.SaveChangesAsync();
                    return response;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<UserModel>> GetAllUser()
        {
            try
            {
                var Alluser = await educationLoanContext.userModels.ToListAsync();
                return Alluser;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserModel> GetUserById(int id)
        {
            try
            {
                logger.LogInformation("Calling database to fetch the User by Id");
                var response2 = await educationLoanContext.userModels.FindAsync(id);
                if (response2 != null)
                {
                    return response2;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error occured while reading User data from database", ex);

                throw;
            }
        }

        public async Task<UserModel> UpdateUser(int id, UserModel userModel)
        {

            try
            {
                logger.LogInformation("Calling database to Update the Exixting User");
                var response3 = await educationLoanContext.userModels.FindAsync(userModel.Id);
                {
                    if (response3 != null)
                    {
                        response3.Email = userModel.Email;
                        response3.UserName = userModel.UserName;
                        response3.Password = userModel.Password;
                        response3.MobileNumber = userModel.MobileNumber;
                        response3.UserRole = userModel.UserRole;
                        educationLoanContext.userModels.Update(response3);
                        await educationLoanContext.SaveChangesAsync();

                        return response3;
                    }
                    else
                    {
                        return null;
                    }


                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error occured while Updating User data to the database", ex);

                throw;
            }
        }
    }
}
