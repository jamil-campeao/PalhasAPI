

using MediatR;
using PalhasAPI.Domain.Enum;

namespace PalhasAPI.Application.Pedidos.Commands.AtualizarStatusPedido
{
    public record AtualizarStatusPedidoCommand(
        Guid Id,
        StatusPedido NovoStatus
        ) : IRequest;
}
