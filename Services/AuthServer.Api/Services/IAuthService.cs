using AuthServer.Api.Models;

namespace AuthServer.Api.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginUser user);
        Task<bool> RegisterUser(LoginUser user);
    }
}