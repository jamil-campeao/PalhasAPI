
using MediatR;

namespace PalhasAPI.Application.Estoque.Commands.RegistrarEntrada
{
    public record RegistrarEntradaCommand(
        Guid ProdutoId,
        int Quantidade,
        string Motivo
        ) : IRequest;
}
