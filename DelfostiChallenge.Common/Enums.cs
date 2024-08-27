namespace DelfostiChallenge.Common
{
    public static class Enums
    {
        public enum EstadoPedido
        {
            PorAtender = 1,

            EnProceso = 2,

            EnDelivery = 3,

            Recibido = 4
        }

        public enum TipoProducto
        {
            Laptops = 1,
            Monitores = 2,
            Teclados = 3,
            Smartphones = 4
        }

        public enum UnidadMedidaProducto
        {
            Unidad = 1,
            Pack = 2
        }

        public enum EtiquetaProducto
        {
            Gaming = 1,
            Profesional = 2,
            Economico = 3,
            Oficina = 4,
            Hogar = 5,
            Tendencia = 6
        }
    }
}
