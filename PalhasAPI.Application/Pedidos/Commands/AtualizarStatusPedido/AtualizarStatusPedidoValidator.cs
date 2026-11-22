using FluentValidation;

namespace PalhasAPI.Application.Pedidos.Commands.AtualizarStatusPedido
{
    public class AtualizarStatusPedidoValidator : AbstractValidator<AtualizarStatusPedidoCommand>
    {
        public AtualizarStatusPedidoValidator()
        {
            RuleFor(x => x.NovoStatus)
                .IsInEnum().WithMessage("Status inválido.");
        }
    }
}
