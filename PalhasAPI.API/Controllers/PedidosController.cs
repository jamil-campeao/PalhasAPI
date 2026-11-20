using MediatR;
using Microsoft.AspNetCore.Mvc;
using PalhasAPI.Application.Pedidos.Commands.AtualizarStatusPedido;
using PalhasAPI.Application.Pedidos.Commands.CriarPedido;
using PalhasAPI.Application.Pedidos.Queries.BuscarPedidoPorId;
using PalhasAPI.Application.Pedidos.Queries.ListarPedidos;

namespace PalhasAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PedidosController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Listar(CancellationToken cancellationToken)
        {
            var resultado = await _mediator.Send(new ListarPedidosQuery(), cancellationToken);
            return Ok(resultado);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> BuscarPorId(Guid id, CancellationToken cancellationToken)
        {
            var resultado = await _mediator.Send(new BuscarPedidoPorIdQuery(id), cancellationToken);

            return Ok(resultado);
        }


        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarPedidoCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(BuscarPorId), new { id }, new { id });
        }

        [HttpPatch("{id:guid}/status")]
        public async Task<IActionResult> AtualizarStatus(Guid id, [FromBody] AtualizarStatusPedidoCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id) return BadRequest("O id da rota não confere com o do body.");

            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
