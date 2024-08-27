using DelfostiChallenge.API.Controllers.v1.Base;
using DelfostiChallenge.Application.Interfaces;
using DelfostiChallenge.DTO.DTOs.Common;
using DelfostiChallenge.DTO.DTOs.Pedido;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DelfostiChallenge.API.Controllers.v1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PedidosController : CustomControllerBase
    {
        private readonly IPedidoApplication _pedidoApplication;

        #region Constructor
        public PedidosController(IPedidoApplication pedidoApplication)
        {
            _pedidoApplication = pedidoApplication;
        }
        #endregion

        /// <summary>
        /// Crea un nuevo Pedido con los datos especificados.
        /// </summary>
        /// <remarks>
        /// **Productos**
        /// (Id = 1) Laptop Pro X1 | (Id = 2) Monitor UltraWide | (Id = 3) Teclado Mecánico RGB | (Id = 4) Smartphone 5G | (Id = 5) Laptop Económica | (Id = 6) Pack Teclado y Mouse Inalámbricos
        /// **RepartidorId** = 2
        /// </remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Response<PedidoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] PedidoCreateDTO request)
        {
            var response = await _pedidoApplication.CreateAsync(request, IdUser);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        /// <summary>
        /// Actualiza el Estado de un Pedido. 
        /// </summary>
        /// <remarks>(Id = 1) **Por Atender** | (Id = 2) **En Proceso** | (Id = 3) **En Delivery** | (Id = 4) **Recibido** </remarks>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] PedidoUpdateStatusDTO request)
        {
            if (id != request.Id || id <= 0)
                return BadRequest();

            var response = await _pedidoApplication.UpdateStatusAsync(request);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
