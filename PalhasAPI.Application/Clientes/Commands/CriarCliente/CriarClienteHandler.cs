using MediatR;
using PalhasAPI.Domain.Entities;
using PalhasAPI.Domain.Interfaces;


namespace PalhasAPI.Application.Clientes.Commands.CriarCliente
{
    public class CriarClienteHandler : IRequestHandler<CriarClienteCommand, Guid>
    {
        private readonly IClienteRepository _repository;

        public CriarClienteHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CriarClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = new Cliente(
                request.Nome,
                request.Telefone,
                request.Observacoes
                );

            await _repository.AddAsync(cliente, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return cliente.Id;
        }
    }
}
