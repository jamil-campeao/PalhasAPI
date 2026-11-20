
using MediatR;
using PalhasAPI.Application.Pedidos.DTOs;
using PalhasAPI.Domain.Enum;

namespace PalhasAPI.Application.Pedidos.Commands.CriarPedido
{
    public record CriarPedidoCommand(
        Guid ClienteId,
        List<CriarPedidoItemDto> Itens,
        decimal Desconto,
        string? Observacoes,
        FormaPagamento FormaPagamento
        ) : IRequest<Guid>;
}
