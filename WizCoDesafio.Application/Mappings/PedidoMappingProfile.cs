using AutoMapper;
using Domain.Entities;
using DomainPedido = Domain.Entities.Pedido;
using WizCoDesafio.Application.Pedido.DTO;
using WizCoDesafio.Domain.Interfaces.Filtros;

namespace WizCoDesafio.Application.Mappings
{
    public class PedidoMappingProfile : Profile
    {
        public PedidoMappingProfile()
        {
            CreateMap<DomainPedido, PedidoDTO>()
                .ForCtorParam("pedidoId", opt => opt.MapFrom(src => src.Id));

            CreateMap<PedidoDTO, DomainPedido>()
                .ConstructUsing((src, context) => new DomainPedido(
                    src.ClienteNome,
                    context.Mapper.Map<List<ItemPedido>>(src.Itens)));

            CreateMap<ItemPedido, ItemPedidoDTO>()
                .ForCtorParam("precoUnitario", opt => opt.MapFrom(src => src.PrecoUnitario));

            CreateMap<ItemPedidoDTO, ItemPedido>()
                .ConstructUsing(src => new ItemPedido(
                    src.ProdutoNome,
                    src.Quantidade,
                    src.PrecoUnitario));

            CreateMap<PedidoFiltro, FiltroPedidoDTO>();
            CreateMap<FiltroPedidoDTO, PedidoFiltro>();
        }
    }
}
