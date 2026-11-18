using MediatR;
using Microsoft.AspNetCore.Mvc;
using PalhasAPI.Application.Produtos.Commands.AtualizarProduto;
using PalhasAPI.Application.Produtos.Commands.CriarProduto;
using PalhasAPI.Application.Produtos.Queries.BuscarProdutoPorid;
using PalhasAPI.Application.Produtos.Queries.ListarProdutos;
using System.Linq.Expressions;

namespace PalhasAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutosController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Listar([FromQuery] string? filtro, CancellationToken cancellationToken)
        {
            var resultado = await _mediator.Send(new ListarProdutosQuery(filtro), cancellationToken);
            return Ok(resultado);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> BuscarPorId(Guid id, CancellationToken cancellationToken)
        {
            var resultado = await _mediator.Send(new BuscarProdutoPorIdQuery(id), cancellationToken);

            if (resultado is null) return NotFound();

            return Ok(resultado);
        }


        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarProdutoCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(BuscarPorId), new { id }, new { id });
        }


        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarProdutoCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id) return BadRequest("O id da rota não confere com o do body");

            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
