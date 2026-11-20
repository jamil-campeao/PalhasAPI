

using MediatR;
using PalhasAPI.Domain.Entities;
using PalhasAPI.Domain.Enum;
using PalhasAPI.Domain.Exceptions;
using PalhasAPI.Domain.Interfaces;

namespace PalhasAPI.Application.Estoque.Commands.RegistrarEntrada
{
    public class RegistrarEntradaHandler : IRequestHandler<RegistrarEntradaCommand>
    {
        private readonly IEstoqueRepository _estoqueRepository;
        private readonly IProdutoRepository _produtoRepository;

        
        public RegistrarEntradaHandler(IEstoqueRepository estoqueRepository, IProdutoRepository produtoRepository)
        {
            _estoqueRepository = estoqueRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task Handle(RegistrarEntradaCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetByIdAsync(request.ProdutoId, cancellationToken) ?? throw new NotFoundException("Produto", request.ProdutoId);

            produto.AdicionarEstoque(request.Quantidade);

            await _produtoRepository.UpdateAsync(produto, cancellationToken);

            var movimentacao = new MovimentacaoEstoque(
                request.ProdutoId,
                TipoMovimentacao.Entrada,
                request.Quantidade,
                request.Motivo,
                null
                );

            await _estoqueRepository.AddAsync(movimentacao, cancellationToken);
            await _estoqueRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
