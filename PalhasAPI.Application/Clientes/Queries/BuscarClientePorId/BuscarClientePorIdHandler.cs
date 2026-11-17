using MediatR;
using PalhasAPI.Application.Clientes.DTOs;
using PalhasAPI.Domain.Interfaces;

namespace PalhasAPI.Application.Clientes.Queries.BuscarClientePorId
{
    public class BuscarClientePorIdHandler : IRequestHandler<BuscarClientePorIdQuery, ClienteDTO?>
    {
        private readonly IClienteRepository _repository;

        public BuscarClientePorIdHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<ClienteDTO?> Handle(BuscarClientePorIdQuery request, CancellationToken cancellationToken)
        {
            var cliente = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (cliente is null) return null;

            return new ClienteDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Telefone = cliente.Telefone,
                Observacoes = cliente.Observacoes,
                Ativo = cliente.Ativo,
                CriadoEm = cliente.CriadoEm
            };
        }
    }
}
