using dotnetapp.Models;
using dotnetapp.Models;

namespace dotnetapp.Core.Interface
{
    public interface IAuthentication
    {
        ResponseModel GenerateToken(Login loginModel);
    }
}
