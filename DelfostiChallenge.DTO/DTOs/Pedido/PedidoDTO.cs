using static DelfostiChallenge.Common.Enums;

namespace DelfostiChallenge.DTO.DTOs.Pedido
{
    public class PedidoDTO
    {
        public int Id { get; set; }
        public string NumeroPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime? FechaRecepcion { get; set; }
        public DateTime? FechaDespacho { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public int VendedorId { get; set; }
        public string NombreVendedor { get; set; }
        public int? RepartidorId { get; set; }
        public string NombreRepartidor { get; set; }
        public EstadoPedido Estado { get; set; }
        public List<PedidoDetalleDTO> PedidoDetalles { get; set; } = new List<PedidoDetalleDTO>();
    }
}
