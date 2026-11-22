using FluentValidation;

namespace PalhasAPI.Application.Clientes.Commands.AtualizarCliente
{
    public class AtualizarClienteValidator : AbstractValidator<AtualizarClienteCommand>
    {
        public AtualizarClienteValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id é obrigatório");

            RuleFor(x => x.Nome)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MinimumLength(3).WithMessage("Nome deve ter no mínimo 3 caracteres.")
                .MaximumLength(150).WithMessage("Nome deve ter no máximo 150 caracteres.");

            RuleFor(x => x.Telefone)
                .MaximumLength(20).WithMessage("Telefone deve ter no máximo 20 caracteres")
                .When(x => x.Telefone != null);
        }
    }
}
