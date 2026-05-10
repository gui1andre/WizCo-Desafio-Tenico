using System;
using System.Collections.Generic;
using System.Text;
using WizCoDesafio.Application.Pedido.DTO;

namespace WizCoDesafio.Application.Pedido.Interfaces
{
    public interface IPedidoService
    {
        Task<PedidoDTO> CriarPedidoAsync(CriarPedidoDTO criarPedidoDTO);
        Task<PedidoDTO?> ObterPedidoPorIdAsync(Guid id);
        Task<List<PedidoDTO>> ObterPedidoAsync(FiltroPedidoDTO filtroPedidoDTO);
        Task<PedidoDTO> FecharPedidoPagoAsync(Guid id);
        Task<PedidoDTO> CancelarPedidoAsync(Guid id);
        Task RemoverPedidoAsync(Guid id);
        Task<ItemPedidoDTO> AdicionarItemAsync(Guid pedidoId, CriarItemDTO criarItemDTO);
        Task<ItemPedidoDTO> AtualizarItemAsync(Guid pedidoId, Guid itemId, AtualizarItemDTO atualizarItemDTO);
        Task RemoverItemAsync(Guid pedidoId, Guid itemId);
    }
}
