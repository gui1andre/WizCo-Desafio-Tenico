using System;
using System.Collections.Generic;
using System.Text;

namespace WizCoDesafio.Domain.Interfaces.Filtros
{
    public record PedidoFiltro(string ClienteNome,
            DateTime? DataInicio,
            DateTime? DataFim,
            decimal ValorMinimo,
            decimal ValorMaximo,
            int Pagina = 1,
            int TamanhoPagina = 20)
    {
    }
}
