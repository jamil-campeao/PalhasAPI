
using MediatR;
using PalhasAPI.Domain.Exceptions;
using PalhasAPI.Domain.Interfaces;

namespace PalhasAPI.Application.Clientes.Commands.AtualizarCliente
{
    public class AtualizarClienteHandler : IRequestHandler<AtualizarClienteCommand>
    {
        private readonly IClienteRepository _repository;

        public AtualizarClienteHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(AtualizarClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _repository.GetByIdAsync(request.Id, cancellationToken) ?? throw new NotFoundException("Cliente", request.Id);
            
            cliente.Atualizar(request.Nome, request.Telefone, request.Observacoes);

            await _repository.UpdateAsync(cliente, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
        }
    }
}
