

using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PalhasAPI.Domain.Entities;
using PalhasAPI.Domain.Interfaces;
using System.Diagnostics.Metrics;

namespace PalhasAPI.Application.Produtos.Commands.CriarProduto
{
    public class CriarProdutoHandler : IRequestHandler<CriarProdutoCommand, Guid>
    {
        private readonly IProdutoRepository _repository;

        public CriarProdutoHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CriarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto(
                request.Nome,
                request.Descricao,
                request.PrecoVenda,
                request.CustoProducao,
                request.Unidade,
                request.EstoqueMinimo
                );

            await _repository.AddAsync(produto, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return produto.Id;
        }
    }
}
