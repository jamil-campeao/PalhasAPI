

using MediatR;
using PalhasAPI.Application.Estoque.DTOs;
using PalhasAPI.Domain.Interfaces;

namespace PalhasAPI.Application.Estoque.Queries.BuscarEstoqueProduto
{
    public class BuscarEstoqueProdutoHandler : IRequestHandler<BuscarEstoqueProdutoQuery, EstoqueProdutoDto?>
    {
        private readonly IProdutoRepository _respository;

        public BuscarEstoqueProdutoHandler(IProdutoRepository repository)
        {
            _respository = repository;
        }

        public async Task<EstoqueProdutoDto?> Handle(BuscarEstoqueProdutoQuery request, CancellationToken cancellationToken)
        {
            var produto = await _respository.GetByIdAsync(request.ProdutoId, cancellationToken);

            if (produto is null) return null;

            return new EstoqueProdutoDto
            {
                ProdutoId = produto.Id,
                NomeProduto = produto.Nome,
                EstoqueAtual = produto.EstoqueAtual,
                EstoqueMinimo = produto.EstoqueMinimo,
                AbaixoDoMinimo = produto.EstoqueAtual < produto.EstoqueMinimo
            };
        }
    }
}
