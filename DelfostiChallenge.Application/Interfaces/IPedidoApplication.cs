using DelfostiChallenge.DTO.DTOs.Common;
using DelfostiChallenge.DTO.DTOs.Pedido;

namespace DelfostiChallenge.Application.Interfaces
{
    public interface IPedidoApplication
    {
        Task<Response<PedidoDTO>> CreateAsync(PedidoCreateDTO request, int IdUser);
        Task<Response<bool>> UpdateStatusAsync(PedidoUpdateStatusDTO request);
    }
}
