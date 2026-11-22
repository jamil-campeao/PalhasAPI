using FluentValidation;

namespace PalhasAPI.Application.Estoque.Commands.RegistrarEntrada
{
    public class RegistrarEntradaValidator : AbstractValidator<RegistrarEntradaCommand>
    {
        public RegistrarEntradaValidator()
        {
            RuleFor(x => x.ProdutoId)
                .NotEmpty().WithMessage("ProdutoId é obrigatório.");

            RuleFor(x => x.Quantidade)
                .GreaterThan(0).WithMessage("Quantidade deve ser maior que zero.");

            RuleFor(x => x.Motivo)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Motivo é obrigatório.")
                .MinimumLength(3).WithMessage("Motivo deve ter no mínimo 3 caracteres")
                .MaximumLength(200).WithMessage("Motivo deve ter no máximo 200 caracteres.");
        }
    }
}
