using static DelfostiChallenge.Common.Enums;

namespace DelfostiChallenge.Core.Entities
{
    public class ProductoEntity
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Nombre { get; set; }
        public TipoProducto Tipo { get; set; }
        public List<EtiquetaProducto> Etiquetas { get; set; } = new List<EtiquetaProducto>();
        public decimal Precio { get; set; }
        public UnidadMedidaProducto UnidadMedida { get; set; }
    }
}
