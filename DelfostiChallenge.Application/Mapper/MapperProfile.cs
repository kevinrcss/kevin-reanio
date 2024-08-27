using AutoMapper;
using DelfostiChallenge.Common;
using DelfostiChallenge.Core.Entities;
using DelfostiChallenge.DTO.DTOs.Pedido;

namespace DelfostiChallenge.Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PedidoCreateDTO, PedidoEntity>()
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => Enums.EstadoPedido.PorAtender))
                .ForMember(dest => dest.FechaPedido, o => o.MapFrom(s => DateTime.Now));

            CreateMap<PedidoDetalleCreateDTO, PedidoDetalleEntity>();
            CreateMap<PedidoEntity, PedidoDTO>();
            CreateMap<PedidoDetalleEntity, PedidoDetalleDTO>();
        }
    }
}
