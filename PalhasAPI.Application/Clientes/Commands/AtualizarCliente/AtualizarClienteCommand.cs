using MediatR;

namespace PalhasAPI.Application.Clientes.Commands.AtualizarCliente
{
    public record AtualizarClienteCommand(
        Guid Id,
        string Nome,
        string? Telefone,
        string? Observacoes
        ) : IRequest;
}
