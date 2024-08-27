using System.ComponentModel.DataAnnotations;

namespace DelfostiChallenge.DTO.DTOs.Pedido
{
    public class PedidoDetalleCreateDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? ProductoId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? Cantidad { get; set; } = 1;
    }
}
