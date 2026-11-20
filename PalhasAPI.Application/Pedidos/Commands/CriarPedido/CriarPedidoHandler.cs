

using MediatR;
using PalhasAPI.Domain.Entities;
using PalhasAPI.Domain.Enum;
using PalhasAPI.Domain.Exceptions;
using PalhasAPI.Domain.Interfaces;

namespace PalhasAPI.Application.Pedidos.Commands.CriarPedido
{
    public class CriarPedidoHandler : IRequestHandler<CriarPedidoCommand, Guid>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IEstoqueRepository _estoqueRepository;


        public CriarPedidoHandler(
            IPedidoRepository pedidoRepository,
            IProdutoRepository produtoRepository,
            IClienteRepository clienteRepository,
            IEstoqueRepository estoqueRepository
            )
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _clienteRepository = clienteRepository;
            _estoqueRepository = estoqueRepository;
        }

        public async Task<Guid> Handle(CriarPedidoCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync(request.ClienteId, cancellationToken) ?? throw new NotFoundException("Cliente", request.ClienteId);

            var numero = $"PED-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString()[..4].ToUpper()}";

            var pedido = new Pedido(numero, request.ClienteId, request.Observacoes);

            foreach (var item in request.Itens)
            {
                var produto = await _produtoRepository.GetByIdAsync(item.ProdutoId, cancellationToken) ?? throw new NotFoundException("Produto", item.ProdutoId);

                produto.RemoverEstoque(item.Quantidade);
                await _produtoRepository.UpdateAsync(produto, cancellationToken);

                var itemPedido = new ItemPedido(item.ProdutoId, item.Quantidade, produto.PrecoVenda);
                pedido.AdicionarItem(itemPedido);

                var movimentacao = new MovimentacaoEstoque(
                    item.ProdutoId,
                    TipoMovimentacao.Saida,
                    item.Quantidade,
                    "Venda",
                    pedido.Id
                    );

                await _estoqueRepository.AddAsync(movimentacao, cancellationToken);
            }

            pedido.AplicarDesconto(request.Desconto);


            var pagamento = new Pagamento(pedido.Id, pedido.Total, request.FormaPagamento, request.FormaPagamento == FormaPagamento.Fiado ? DateTime.UtcNow.AddDays(30) : null);

            pedido.AdicionarPagamento(pagamento);

            await _pedidoRepository.AddAsync(pedido, cancellationToken);
            await _pedidoRepository.SaveChangesAsync(cancellationToken);

            return pedido.Id;
        }
    }
}
