using static DelfostiChallenge.Common.Enums;

namespace DelfostiChallenge.Core.Entities
{
    public class PedidoEntity
    {
        public int Id { get; set; }
        public string NumeroPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime? FechaRecepcion { get; set; }
        public DateTime? FechaDespacho { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public int VendedorId { get; set; }
        public UsuarioEntity Vendedor { get; set; }
        public int? RepartidorId { get; set; }
        public UsuarioEntity Repartidor { get; set; }
        public EstadoPedido Estado { get; set; }
        public List<PedidoDetalleEntity> PedidoDetalles { get; set; } = new List<PedidoDetalleEntity>();
    }
}
