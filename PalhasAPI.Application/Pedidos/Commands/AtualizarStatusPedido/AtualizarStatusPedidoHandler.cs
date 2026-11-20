

using MediatR;
using PalhasAPI.Domain.Exceptions;
using PalhasAPI.Domain.Interfaces;

namespace PalhasAPI.Application.Pedidos.Commands.AtualizarStatusPedido
{
    public class AtualizarStatusPedidoHandler : 
        IRequestHandler<AtualizarStatusPedidoCommand>
    {
        private readonly IPedidoRepository _repository;

        public AtualizarStatusPedidoHandler(IPedidoRepository repository)
        {
            _repository = repository;
        }


        public async Task Handle(AtualizarStatusPedidoCommand request, CancellationToken cancellationToken)
        {
            var pedido = await _repository.GetByIdAsync(request.Id, cancellationToken) ?? throw new NotFoundException("Pedido", request.Id);

            pedido.AtualizarStatus(request.NovoStatus);

            await _repository.UpdateAsync(pedido, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
        }
    }
}
