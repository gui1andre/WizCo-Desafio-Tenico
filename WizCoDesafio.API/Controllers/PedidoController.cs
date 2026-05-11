using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WizCoDesafio.Application.Pedido.DTO;
using WizCoDesafio.Application.Pedido.Interfaces;

namespace WizCoDesafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public async Task<ActionResult<PedidoDTO>> CriarPedido(CriarPedidoDTO request, [FromServices] IValidator<CriarPedidoDTO> validator)
        {
            var result = await validator.ValidateAsync(request);

            if (!result.IsValid)
                return BadRequest(result.Errors.Select(e => e.ErrorMessage));

            var pedido = await _pedidoService.CriarPedidoAsync(request);

            return CreatedAtAction(nameof(ObterPedido), new { id = pedido.PedidoId }, pedido);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoDTO>> ObterPedido(Guid id)
        {
            var pedido = await _pedidoService.ObterPedidoPorIdAsync(id);

            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoDTO>>> ObterPedidos([FromQuery] FiltroPedidoDTO filtro, [FromServices] IValidator<FiltroPedidoDTO> validator)
        {
            var result = await validator.ValidateAsync(filtro);

            if (!result.IsValid)
                return BadRequest(result.Errors.Select(e => e.ErrorMessage));

            var pedidos = await _pedidoService.ObterPedidoAsync(filtro);
            return Ok(pedidos);
        }

        [HttpPut("{id}/cancelar")]
        public async Task<IActionResult> CancelarPedido(Guid id)
        {
            var result = await _pedidoService.CancelarPedidoAsync(id);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}/pagar")]
        public async Task<IActionResult> PagarPedido(Guid id)
        {
            var pedido = await _pedidoService.FecharPedidoPagoAsync(id);

            if (pedido == null)
                return NotFound();

            return NoContent();
        }

        [HttpPost("{pedidoId}/itens")]
        public async Task<ActionResult<ItemPedidoDTO>> AdicionarItem(Guid pedidoId, CriarItemDTO criarItemDTO, [FromServices] IValidator<CriarItemDTO> validator)
        {
            var result = await validator.ValidateAsync(criarItemDTO);

            if (!result.IsValid)
                return BadRequest(result.Errors.Select(e => e.ErrorMessage));

            var item = await _pedidoService.AdicionarItemAsync(pedidoId, criarItemDTO);

            if (item == null)
                return NotFound();

            return CreatedAtAction(nameof(ObterPedido), new { id = pedidoId }, item);


        }

        [HttpDelete("{pedidoId}/itens/{itemId}")]
        public async Task<IActionResult> RemoverItem(Guid pedidoId, Guid itemId)
        {
            await _pedidoService.RemoverItemAsync(pedidoId, itemId);
            return NoContent();
        }

        [HttpPut("{pedidoId}/itens/{itemId}")]
        public async Task<ActionResult<ItemPedidoDTO>> AtualizarItem(Guid pedidoId, Guid itemId, AtualizarItemDTO atualizarItemDTO, [FromServices] IValidator<AtualizarItemDTO> validator)
        {
            var result = await validator.ValidateAsync(atualizarItemDTO);

            if (!result.IsValid)
                return BadRequest(result.Errors.Select(e => e.ErrorMessage));

            var item = await _pedidoService.AtualizarItemAsync(pedidoId, itemId, atualizarItemDTO);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

    }
}
