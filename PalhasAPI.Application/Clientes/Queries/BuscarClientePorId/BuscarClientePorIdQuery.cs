using MediatR;
using PalhasAPI.Application.Clientes.DTOs;

namespace PalhasAPI.Application.Clientes.Queries.BuscarClientePorId
{
    public record BuscarClientePorIdQuery(Guid Id) : IRequest<ClienteDTO>;
}
