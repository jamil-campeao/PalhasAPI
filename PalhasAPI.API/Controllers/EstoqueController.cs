using MediatR;
using Microsoft.AspNetCore.Mvc;
using PalhasAPI.Application.Estoque.Commands.RegistrarEntrada;
using PalhasAPI.Application.Estoque.Commands.RegistrarSaida;
using PalhasAPI.Application.Estoque.Queries.BuscarEstoqueProduto;
using PalhasAPI.Application.Estoque.Queries.ListarMovimentacoes;

namespace PalhasAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EstoqueController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("movimentacoes")]
        public async Task<IActionResult> ListarMovimentacoes([FromQuery] Guid? produtoId, CancellationToken cancellationToken)
        {
            var resultado = await _mediator.Send(new ListarMovimentacoesQuery(produtoId), cancellationToken);
            return Ok(resultado);
        }

        [HttpGet("produto/{produtoId:guid}")]
        public async Task<IActionResult> BuscarEstoqueProduto(Guid produtoId, CancellationToken cancellationToken)
        {
            var resultado = await _mediator.Send(new BuscarEstoqueProdutoQuery(produtoId), cancellationToken);

            if (resultado is null) return NotFound();

            return Ok(resultado);
        }

        [HttpPost("entrada")]
        public async Task<IActionResult> RegistrarEntrada([FromBody] RegistrarEntradaCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }


        [HttpPost("saida")]
        public async Task<IActionResult> RegistrarSaida([FromBody] RegistrarSaidaCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

    }
}
