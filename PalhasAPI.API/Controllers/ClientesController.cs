using MediatR;
using Microsoft.AspNetCore.Mvc;
using PalhasAPI.Application.Clientes.Commands.AtualizarCliente;
using PalhasAPI.Application.Clientes.Commands.CriarCliente;
using PalhasAPI.Application.Clientes.Queries.BuscarClientePorId;
using PalhasAPI.Application.Clientes.Queries.ListarClientes;


namespace PalhasAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Listar([FromQuery] string? filtro, CancellationToken cancellationToken)
        {
            var resultado = await _mediator.Send(new ListarClientesQuery(filtro), cancellationToken);
            return Ok(resultado);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> BuscarPorId(Guid id, CancellationToken cancellationToken)
        {
            var resultado = await _mediator.Send(new BuscarClientePorIdQuery(id), cancellationToken);

            if (resultado is null) return NotFound();

            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarClienteCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(BuscarPorId), new { id }, new { id });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarClienteCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id) return BadRequest("O id da rota não confere com o do body");

            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
