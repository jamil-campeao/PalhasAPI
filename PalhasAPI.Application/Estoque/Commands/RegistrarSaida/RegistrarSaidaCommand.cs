using MediatR;

namespace PalhasAPI.Application.Estoque.Commands.RegistrarSaida
{
    public record RegistrarSaidaCommand(
        Guid ProdutoId,
        int Quantidade,
        string Motivo
        ) : IRequest;
}
