using MediatR;
using PalhasAPI.Application.Clientes.DTOs;

namespace PalhasAPI.Application.Clientes.Queries.ListarClientes
{
    public record ListarClientesQuery(
        string? Filtro = null
        ) : IRequest<List<ClienteDTO>>;
}
