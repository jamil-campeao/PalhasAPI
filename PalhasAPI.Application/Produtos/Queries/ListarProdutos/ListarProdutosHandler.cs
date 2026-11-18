

using MediatR;
using PalhasAPI.Application.Produtos.DTOs;
using PalhasAPI.Domain.Interfaces;

namespace PalhasAPI.Application.Produtos.Queries.ListarProdutos
{
    public class ListarProdutosHandler : IRequestHandler<ListarProdutosQuery, List<ProdutoDto>>
    {
        private readonly IProdutoRepository _repository;

        public ListarProdutosHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProdutoDto>> Handle(ListarProdutosQuery request, CancellationToken cancellationToken)
        {
            var produtos = await _repository.GetAllAsync(request.Filtro, cancellationToken);

            return produtos.Select(p => new ProdutoDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                PrecoVenda = p.PrecoVenda,
                CustoProducao = p.CustoProducao,
                Unidade = p.Unidade,
                EstoqueAtual = p.EstoqueAtual,
                EstoqueMinimo = p.EstoqueMinimo,
                Ativo = p.Ativo,
                CriadoEm = p.CriadoEm
            }).ToList();
        }
    }
}
