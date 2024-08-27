using DelfostiChallenge.API.Controllers.v1.Base;
using DelfostiChallenge.Application.Interfaces;
using DelfostiChallenge.DTO.DTOs.Auth;
using DelfostiChallenge.DTO.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace DelfostiChallenge.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : CustomControllerBase
    {
        private readonly IAuthApplication _authApplication;

        #region Constructor
        public AuthController(IAuthApplication authApplication)
        {
            _authApplication = authApplication;
        }
        #endregion

        /// <summary>
        /// Permite autenticarse para obtener un token.
        /// </summary>
        /// <remarks>
        /// **username:** kevin.rc@hotmail.com 
        /// **password:** 123456
        /// </remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [ProducesResponseType(typeof(Response<AuthDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(LoginDTO request)
        {
            var reply = await _authApplication.LoginAsync(request);
            if (!reply.Success)
            {
                return BadRequest(reply);
            }
            return Ok(reply);
        }
    }
}
