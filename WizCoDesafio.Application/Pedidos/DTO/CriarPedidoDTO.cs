using Domain.Entities.Enums;

namespace WizCoDesafio.Application.Pedido.DTO
{
    public record CriarPedidoDTO(string ClienteNome, IEnumerable<CriarItemDTO> Itens);
}
