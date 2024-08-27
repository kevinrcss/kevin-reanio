using AutoMapper;
using DelfostiChallenge.Application.Interfaces;
using DelfostiChallenge.Common;
using DelfostiChallenge.Core.Entities;
using DelfostiChallenge.Core.Interfaces;
using DelfostiChallenge.DTO.DTOs.Auth;
using DelfostiChallenge.DTO.DTOs.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DelfostiChallenge.Application.Implementations
{
    public class AuthApplication : IAuthApplication
    {
        private readonly ILogger<AuthApplication> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        #region Constructor
        public AuthApplication(ILogger<AuthApplication> logger,
            IMapper mapper, IAuthRepository authRepository, IConfiguration configuration)
        {
            _logger = logger;
            _mapper = mapper;
            _authRepository = authRepository;
            _configuration = configuration;
        }

        #endregion

        public async Task<Response<AuthDTO>> LoginAsync(LoginDTO request)
        {
            var response = new Response<AuthDTO>();
            try
            {
                request.Password = await HasherManager.HashAsync(request.Password);

                UsuarioEntity user = await _authRepository.Login(request);
                if (user == null)
                {
                    response.Message = Messages.GENERAL_INVALIDDATA;
                    return response;
                }

                JwtDTO jwtDTO = GenerateToken(user);

                if (String.IsNullOrEmpty(jwtDTO.Token))
                {
                    response.Message = Messages.GENERAL_ERROR;
                    return response;
                }

                response.Data = new AuthDTO
                {
                    Token = jwtDTO.Token,
                    TokenExpiration = jwtDTO.TokenExpiration,
                    Nombre = user.Nombre,
                    Usuario = user.Correo
                };
                response.Message = Messages.GENERAL_OK;
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Message = Messages.GENERAL_EXCEPTION;
                _logger.LogError(string.Concat(ex.Message, ex.InnerException?.Message, "\n", ex.StackTrace));
            }
            return response;
        }

        #region Private Methods
        private JwtDTO GenerateToken(UsuarioEntity user)
        {
            var secretKey = _configuration.GetRequiredSection("Jwt:SecretKey").Value;
            var time = _configuration.GetRequiredSection("Jwt:Time").Value;

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Name, user.Nombre),
                    new Claim(JwtRegisteredClaimNames.Email, user.Correo),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                })),
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(time)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)), SecurityAlgorithms.HmacSha256),

            };
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return new JwtDTO { Token = jwtTokenHandler.WriteToken(token), TokenExpiration = tokenDescriptor.Expires };
        }
        #endregion
    }
}
