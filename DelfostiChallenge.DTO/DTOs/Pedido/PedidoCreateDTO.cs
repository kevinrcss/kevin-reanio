using DelfostiChallenge.DTO.Validations;

namespace DelfostiChallenge.DTO.DTOs.Pedido
{
    public class PedidoCreateDTO
    {
        [NullablePositiveInteger]
        public int? RepartidorId { get; set; }
        public List<PedidoDetalleCreateDTO> PedidoDetalles { get; set; }
    }
}
