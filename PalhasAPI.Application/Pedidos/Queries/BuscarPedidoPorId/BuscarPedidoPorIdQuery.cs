

using MediatR;
using PalhasAPI.Application.Pedidos.DTOs;

namespace PalhasAPI.Application.Pedidos.Queries.BuscarPedidoPorId
{
    public record BuscarPedidoPorIdQuery(Guid Id) : IRequest<PedidoDto?>;
}
