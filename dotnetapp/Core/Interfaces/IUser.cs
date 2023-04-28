using dotnetapp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace dotnetapp.Core.Interfaces
{
    public interface IUser
    {
        Task<UserModel> GetUserById(int id);
        Task<UserModel> AddUSer(UserModel userModel);
        Task<UserModel> UpdateUser(int id, UserModel userModel);
        Task<UserModel> DeleteUser(int id);

        Task<IEnumerable<UserModel>> GetAllUser();
    }
}
