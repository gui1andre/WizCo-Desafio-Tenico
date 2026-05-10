using System;
using System.Collections.Generic;
using System.Text;

namespace WizCoDesafio.Application.Pedido.DTO
{
    public record ItemPedidoDTO(Guid Id, Guid PedidoId, string ProdutoNome, int Quantidade, decimal PrecoUnitario, DateTime CriadoEm)
    {
    }
}
