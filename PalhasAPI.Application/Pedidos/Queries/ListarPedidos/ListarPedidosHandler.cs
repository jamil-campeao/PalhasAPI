

using MediatR;
using PalhasAPI.Application.Pedidos.DTOs;
using PalhasAPI.Domain.Interfaces;

namespace PalhasAPI.Application.Pedidos.Queries.ListarPedidos
{
    public class ListarPedidosHandler : IRequestHandler<ListarPedidosQuery, List<PedidoDto>>
    {
        private readonly IPedidoRepository _repository;

        public ListarPedidosHandler(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PedidoDto>> Handle(ListarPedidosQuery request, CancellationToken cancellationToken)
        {
            var pedidos = await _repository.GetAllAsync(cancellationToken);

            return pedidos.Select(p => new PedidoDto
            {
                Id = p.Id,
                Numero = p.Numero,
                ClienteId = p.ClienteId,
                NomeCliente = p.Cliente.Nome,
                Status = p.Status,
                StatusDescricao = p.Status.ToString(),
                Subtotal = p.Subtotal,
                Desconto = p.Desconto,
                Total = p.Total,
                Observacoes = p.Observacoes,
                CriadoEm = p.CriadoEm,
                Itens = p.Itens.Select(i => new ItemPedidoDto
                {
                    ProdutoId = i.ProdutoId,
                    NomeProduto = i.Produto.Nome,
                    Quantidade = i.Quantidade,
                    PrecoUnitario = i.PrecoUnitario,
                    Subtotal = i.Subtotal
                }).ToList()
            }).ToList();
        }
    }
}
