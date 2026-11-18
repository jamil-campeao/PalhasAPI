

using MediatR;
using PalhasAPI.Application.Produtos.DTOs;
using PalhasAPI.Domain.Interfaces;

namespace PalhasAPI.Application.Produtos.Queries.BuscarProdutoPorid
{
    public class BuscarProdutoPorIdHandler : IRequestHandler<BuscarProdutoPorIdQuery, ProdutoDto?>
    {
        private readonly IProdutoRepository _repository;

        public BuscarProdutoPorIdHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProdutoDto?> Handle(BuscarProdutoPorIdQuery request, CancellationToken cancellationToken)
        {
            var produto = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (produto is null) return null;

            return new ProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                PrecoVenda = produto.PrecoVenda,
                CustoProducao = produto.CustoProducao,
                Unidade = produto.Unidade,
                EstoqueAtual = produto.EstoqueAtual,
                EstoqueMinimo = produto.EstoqueMinimo,
                Ativo = produto.Ativo,
                CriadoEm = produto.CriadoEm
            };
        }
    }
}
