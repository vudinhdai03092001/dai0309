using BackendAPI.Helpers.Common;
using BackendAPI.Models;

namespace BackendAPI.Services.Users
{
    public interface IUserService
    {
        //List<LoginRequest> FillAll();
        Task<ApiResult<string>> Authencate(LoginRequest request);

        Task<ApiResult<string>> Register(RegisterRequest request);
    }
}
