

using MediatR;
using PalhasAPI.Domain.Interfaces;

namespace PalhasAPI.Application.Produtos.Commands.AtualizarProduto
{
    public class AutalizarProdutoHandler : IRequestHandler<AtualizarProdutoCommand>
    {
        private readonly IProdutoRepository _repository;

        public AutalizarProdutoHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(AtualizarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _repository.GetByIdAsync(request.Id, cancellationToken) ?? throw new Exception("Produto não encontrado");

            produto.Atualizar(
                request.Nome,
                request.Descricao,
                request.PrecoVenda,
                request.CustoProducao,
                request.Unidade,
                request.EstoqueMinimo
                );

            await _repository.UpdateAsync(produto, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
        }

    }
}
