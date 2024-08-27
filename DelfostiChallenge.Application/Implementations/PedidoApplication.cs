using AutoMapper;
using DelfostiChallenge.Application.Interfaces;
using DelfostiChallenge.Common;
using DelfostiChallenge.Core.Entities;
using DelfostiChallenge.Core.Interfaces;
using DelfostiChallenge.DTO.DTOs.Common;
using DelfostiChallenge.DTO.DTOs.Pedido;
using Microsoft.Extensions.Logging;

namespace DelfostiChallenge.Application.Implementations
{
    public class PedidoApplication : IPedidoApplication
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ISecuenciaRepository _secuenciaRepository;
        private readonly ILogger<PedidoApplication> _logger;
        private readonly IMapper _mapper;

        #region Constructor
        public PedidoApplication(IPedidoRepository pedidoRepository,
            ISecuenciaRepository secuenciaRepository,
            ILogger<PedidoApplication> logger,
            IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _logger = logger;
            _mapper = mapper;
            _secuenciaRepository = secuenciaRepository;
        }
        #endregion

        public async Task<Response<PedidoDTO>> CreateAsync(PedidoCreateDTO request, int IdUser)
        {
            var response = new Response<PedidoDTO>();
            try
            {
                var pedidoEntity = _mapper.Map<PedidoEntity>(request);
                pedidoEntity.VendedorId = IdUser;
                pedidoEntity.NumeroPedido = await GenerateNumeroPedidoAsync();

                PedidoEntity createdPedido = await _pedidoRepository.CreateAsync(pedidoEntity);

                response.Data = _mapper.Map<PedidoDTO>(createdPedido);
                response.Success = true;
                response.Message = Messages.GENERAL_OK;
            }
            catch (Exception ex)
            {
                response.Message = Messages.GENERAL_EXCEPTION;
                _logger.LogError(string.Concat(ex.Message, ex.InnerException?.Message, "\n", ex.StackTrace));
            }
            return response;
        }

        public async Task<Response<bool>> UpdateStatusAsync(PedidoUpdateStatusDTO request)
        {
            var response = new Response<bool>();
            try
            {
                var pedido = await _pedidoRepository.GetByIdAsync(request.Id.Value);
                if (pedido == null)
                {
                    response.Message = Messages.GENERAL_NOTFOUND;
                    return response;
                }

                if (!IsValidStatusTransition(pedido.Estado, request.Estado))
                {
                    response.Message = "Transición de estado no válida.";
                    return response;
                }

                pedido.Estado = request.Estado;
                UpdatePedidoDateBasedOnStatus(pedido);

                var updated = await _pedidoRepository.UpdateAsync(pedido);
                response.Data = updated;
                response.Success = updated;
                response.Message = updated ? Messages.GENERAL_OK : Messages.GENERAL_ERROR;
            }
            catch (Exception ex)
            {
                response.Message = Messages.GENERAL_EXCEPTION;
                _logger.LogError(string.Concat(ex.Message, ex.InnerException?.Message, "\n", ex.StackTrace));
            }
            return response;
        }

        #region Private Methods
        private async Task<string> GenerateNumeroPedidoAsync()
        {
            int sequence = await _secuenciaRepository.GetNextSequenceValueAsync("PedidoSequence");
            return $"P{sequence:D5}";
        }

        private bool IsValidStatusTransition(Enums.EstadoPedido currentStatus, Enums.EstadoPedido newStatus)
        {
            return newStatus > currentStatus;
        }

        private void UpdatePedidoDateBasedOnStatus(PedidoEntity pedido)
        {
            switch (pedido.Estado)
            {
                case Enums.EstadoPedido.EnProceso:
                    pedido.FechaRecepcion = DateTime.Now;
                    break;
                case Enums.EstadoPedido.EnDelivery:
                    pedido.FechaDespacho = DateTime.Now;
                    break;
                case Enums.EstadoPedido.Recibido:
                    pedido.FechaEntrega = DateTime.Now;
                    break;
            }
        }
        #endregion
    }
}
