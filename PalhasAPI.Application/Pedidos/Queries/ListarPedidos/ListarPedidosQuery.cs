

using MediatR;
using PalhasAPI.Application.Pedidos.DTOs;

namespace PalhasAPI.Application.Pedidos.Queries.ListarPedidos
{
    public record ListarPedidosQuery() : IRequest<List<PedidoDto>>;
}
