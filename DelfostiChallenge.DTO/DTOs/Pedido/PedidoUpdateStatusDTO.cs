using System.ComponentModel.DataAnnotations;
using static DelfostiChallenge.Common.Enums;

namespace DelfostiChallenge.DTO.DTOs.Pedido
{
    public class PedidoUpdateStatusDTO
    {
        [Required]
        public int? Id { get; set; }

        [Required]
        public EstadoPedido Estado { get; set; }
    }
}
