using dotnetapp.Models;
using dotnetapp.Models;

namespace dotnetapp.Core.Interfaces
{
    public interface IAuthentication
    {


        ResponseModel GenerateToken(Login loginModel);
    }
}
