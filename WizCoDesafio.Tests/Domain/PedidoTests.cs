using Domain.Entities;
using Domain.Entities.Enums;
using Xunit;

namespace WizCoDesafio.Tests.Domain;

public class PedidoTests
{
    [Fact]
    public void DeveCriarPedidoComStatusNovoEValorTotalCalculado()
    {
        var pedidoId = Guid.NewGuid();

        var itens = new List<ItemPedido>
        {
            new("Produto A", 2, 10m, pedidoId),
            new("Produto B", 1, 15m, pedidoId)
        };

        var pedido = new Pedido("Cliente Válido", itens);

        Assert.Equal(PedidoStatusEnum.Novo, pedido.Status);
        Assert.Equal(35m, pedido.ValorTotal);
        Assert.Equal(2, pedido.Itens.Count);
    }

    [Fact]
    public void NaoDevePermitirPedidoSemItens()
    {
        Assert.Throws<ArgumentException>(() => new Pedido("Cliente Válido", []));
    }

    [Fact]
    public void DeveRecalcularValorTotalAoAdicionarItem()
    {
        var pedidoId = Guid.NewGuid();
        var pedido = new Pedido("Cliente Válido", [new ItemPedido("Produto A", 1, 10m, pedidoId)]);

        pedido.AdicionarItem(new ItemPedido("Produto B", 2, 5m, pedido.Id));

        Assert.Equal(20m, pedido.ValorTotal);
    }

    [Fact]
    public void DeveRecalcularValorTotalAoRemoverItem()
    {
        var pedidoId = Guid.NewGuid();
        var item1 = new ItemPedido("Produto A", 1, 10m, pedidoId);
        var item2 = new ItemPedido("Produto B", 2, 5m, pedidoId);
        var pedido = new Pedido("Cliente Válido", [item1, item2]);

        pedido.RemoverItem(item2.Id);

        Assert.Equal(10m, pedido.ValorTotal);
        Assert.Single(pedido.Itens);
    }

    [Fact]
    public void DeveRecalcularValorTotalAoAtualizarItem()
    {
        var pedidoId = Guid.NewGuid();
        var item = new ItemPedido("Produto A", 1, 10m, pedidoId);
        var pedido = new Pedido("Cliente Válido", [item]);

        item.AtualizarItemPedido("Produto A", 3, 10m);
        pedido.AtualizarItem(item);

        Assert.Equal(30m, pedido.ValorTotal);
    }

    [Fact]
    public void PedidoPagoNaoPodeSerCancelado()
    {
        var pedidoId = Guid.NewGuid();
        var pedido = new Pedido("Cliente Válido", [new ItemPedido("Produto A", 1, 10m, pedidoId)]);
        pedido.AtualizarStatus(PedidoStatusEnum.Pago);

        Assert.Throws<InvalidOperationException>(() => pedido.AtualizarStatus(PedidoStatusEnum.Cancelado));
    }
}