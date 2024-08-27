using DelfostiChallenge.Core.Entities;
using DelfostiChallenge.Core.Interfaces;
using DelfostiChallenge.DTO.DTOs.Auth;
using DelfostiChallenge.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace DelfostiChallenge.Repository.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _appDbContext;

        #region Constructor
        public AuthRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        #endregion

        public async Task<UsuarioEntity> Login(LoginDTO request)
        {
            return await _appDbContext.Usuarios.AsNoTracking()
                .SingleOrDefaultAsync(x =>
                x.Correo.Equals(request.Username) &&
                x.Password.Equals(request.Password));
        }
    }
}
