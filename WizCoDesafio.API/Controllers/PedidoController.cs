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
        public async Task<ActionResult<PedidoDTO>> CriarPedido(CriarPedidoDTO request)
        {
            var pedido = await _pedidoService.CriarPedidoAsync(request);

            return CreatedAtAction(nameof(ObterPedido), new { id = pedido.PedidoId }, pedido);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPedido(Guid id)
        {
            var result = await _pedidoService.ObterPedidoPorIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoDTO>>> ObterPedidos([FromQuery] FiltroPedidoDTO filtro)
        {
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


    }
}
