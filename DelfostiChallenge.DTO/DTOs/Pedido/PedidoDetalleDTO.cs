namespace DelfostiChallenge.DTO.DTOs.Pedido
{
    public class PedidoDetalleDTO
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
    }
}
