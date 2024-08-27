namespace DelfostiChallenge.Core.Entities
{
    public class PedidoDetalleEntity
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
        public ProductoEntity Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
