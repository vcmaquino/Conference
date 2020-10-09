using AutoMapper;
using Conferencia.Aplication.DTO;
using Conferencia.Domain.Entity;

namespace Conferencia.Aplication.Mappers
{
    public class ModelToDto : Profile
    {
        public ModelToDto()
        {
            PedidoMap();
        }

        private void PedidoMap()
        {

            CreateMap<OrderDto, OrderEntity>()
                   .ForMember(dest => dest.Id, opt => opt.Ignore())
                   .ForMember(dest => dest.NomeDoConsumidor, opt => opt.MapFrom(x => x.NomeDoConsumidor))
                   .ForMember(dest => dest.Quantidade, opt => opt.MapFrom(x => x.Quantidade))
                   .ForMember(dest => dest.Codigo, opt => opt.MapFrom(x => x.Codigo))
                   .ForMember(dest => dest.Embalagem, opt => opt.MapFrom(x => x.Embalagem))
                   .ForMember(dest => dest.Bebida, opt => opt.MapFrom(x => x.Bebida));
        }
    }

}
