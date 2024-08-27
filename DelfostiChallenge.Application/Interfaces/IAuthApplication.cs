using DelfostiChallenge.DTO.DTOs.Auth;
using DelfostiChallenge.DTO.DTOs.Common;

namespace DelfostiChallenge.Application.Interfaces
{
    public interface IAuthApplication
    {
        Task<Response<AuthDTO>> LoginAsync(LoginDTO request);
    }
}
