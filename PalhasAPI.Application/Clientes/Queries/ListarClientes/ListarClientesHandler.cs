
using MediatR;
using PalhasAPI.Application.Clientes.DTOs;
using PalhasAPI.Domain.Interfaces;

namespace PalhasAPI.Application.Clientes.Queries.ListarClientes
{
    public class ListarClientesHandler : IRequestHandler<ListarClientesQuery, List<ClienteDTO>>
    {
        private readonly IClienteRepository _repository;

        public ListarClientesHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ClienteDTO>> Handle(ListarClientesQuery request, CancellationToken cancellationToken)
        {
            var clientes = await _repository.GetAllAsync(request.Filtro, cancellationToken);

            return clientes.Select(c => new ClienteDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                Telefone = c.Telefone,
                Observacoes = c.Observacoes,
                Ativo = c.Ativo,
                CriadoEm = c.CriadoEm
            }).ToList();
        }
    }
}
