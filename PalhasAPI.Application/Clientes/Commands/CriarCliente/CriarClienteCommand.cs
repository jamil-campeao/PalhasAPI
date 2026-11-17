using MediatR;

namespace PalhasAPI.Application.Clientes.Commands.CriarCliente
{
    public record CriarClienteCommand(
        string Nome,
        string? Telefone,
        string? Observacoes
        ) : IRequest<Guid>;
}
