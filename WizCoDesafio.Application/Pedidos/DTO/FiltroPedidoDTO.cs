using System;
using System.Collections.Generic;
using System.Text;

namespace WizCoDesafio.Application.Pedido.DTO
{
    public record FiltroPedidoDTO(string ClienteNome,
            DateTime? DataInicio,
            DateTime? DataFim,
            decimal ValorMinimo,
            decimal ValorMaximo,
            int Pagina = 1,
            int TamanhoPagina = 20)
    {
    }
}
