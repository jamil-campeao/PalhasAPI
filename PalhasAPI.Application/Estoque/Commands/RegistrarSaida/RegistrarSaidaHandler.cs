using MediatR;
using PalhasAPI.Domain.Entities;
using PalhasAPI.Domain.Enum;
using PalhasAPI.Domain.Exceptions;
using PalhasAPI.Domain.Interfaces;

namespace PalhasAPI.Application.Estoque.Commands.RegistrarSaida
{
    public class RegistrarSaidaHandler : IRequestHandler<RegistrarSaidaCommand>
    {
        private readonly IEstoqueRepository _estoqueRepository;
        private readonly IProdutoRepository _produtoRepository;


        public RegistrarSaidaHandler(IEstoqueRepository estoqueRepository, IProdutoRepository produtoRepository)
        {
            _estoqueRepository = estoqueRepository;
            _produtoRepository = produtoRepository;
        }


        public async Task Handle(RegistrarSaidaCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetByIdAsync(request.ProdutoId, cancellationToken) ?? throw new NotFoundException("Produto", request.ProdutoId);

            produto.RemoverEstoque(request.Quantidade);

            await _produtoRepository.UpdateAsync(produto, cancellationToken);

            var movimentacao = new MovimentacaoEstoque(
                request.ProdutoId,
                TipoMovimentacao.Saida,
                request.Quantidade,
                request.Motivo,
                null
                );

            await _estoqueRepository.AddAsync(movimentacao, cancellationToken);
            await _estoqueRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
