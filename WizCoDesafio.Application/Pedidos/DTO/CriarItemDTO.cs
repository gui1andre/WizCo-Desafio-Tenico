using System;
using System.Collections.Generic;
using System.Text;

namespace WizCoDesafio.Application.Pedido.DTO
{
    public record CriarItemDTO(string ProdutoNome, int Quantidade, decimal PrecoUnitario)
    {
    }
}
