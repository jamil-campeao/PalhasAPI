
using MediatR;
using PalhasAPI.Application.Pedidos.DTOs;
using PalhasAPI.Domain.Exceptions;
using PalhasAPI.Domain.Interfaces;

namespace PalhasAPI.Application.Pedidos.Queries.BuscarPedidoPorId
{
    public class BuscarPedidoPorIdHandler : IRequestHandler<BuscarPedidoPorIdQuery, PedidoDto?>
    {
        private readonly IPedidoRepository _repository;

        public BuscarPedidoPorIdHandler(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public async Task<PedidoDto?> Handle(BuscarPedidoPorIdQuery request, CancellationToken cancellationToken)
        {
            var pedido = await _repository.GetByIdAsync(request.Id, cancellationToken)
                ?? throw new NotFoundException("Pedido", request.Id);

            return new PedidoDto
            {
                Id = pedido.Id,
                Numero = pedido.Numero,
                ClienteId = pedido.ClienteId,
                NomeCliente = pedido.Cliente.Nome,
                Status = pedido.Status,
                StatusDescricao = pedido.Status.ToString(),
                Subtotal = pedido.Subtotal,
                Desconto = pedido.Desconto,
                Total = pedido.Total,
                Observacoes = pedido.Observacoes,
                CriadoEm = pedido.CriadoEm,
                Itens = pedido.Itens.Select(i => new ItemPedidoDto
                {
                    ProdutoId = i.ProdutoId,
                    NomeProduto = i.Produto.Nome,
                    Quantidade = i.Quantidade,
                    PrecoUnitario = i.PrecoUnitario,
                    Subtotal = i.Subtotal
                }).ToList()
            };
        }
    }
}
