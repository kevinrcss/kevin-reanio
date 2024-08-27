using DelfostiChallenge.Core.Entities;
using DelfostiChallenge.DTO.DTOs.Auth;

namespace DelfostiChallenge.Core.Interfaces
{
    public interface IAuthRepository
    {
        Task<UsuarioEntity> Login(LoginDTO request);
    }
}
