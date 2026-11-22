using FluentValidation;

namespace PalhasAPI.Application.Produtos.Commands.AtualizarProduto
{
    public class AtualizarProdutoValidator : AbstractValidator<AtualizarProdutoCommand>
    {
        public AtualizarProdutoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id é obrigatório.");

            RuleFor(x => x.Nome)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(150).WithMessage("Nome deve ter no máximo 150 caracteres.");

            RuleFor(x => x.PrecoVenda)
                .GreaterThan(0).WithMessage("Preço de venda deve ser maior que zero.");

            RuleFor(x => x.CustoProducao)
                .GreaterThanOrEqualTo(0).WithMessage("Custo de produção não pode ser negativo.");

            RuleFor(x => x.Unidade)
                .NotEmpty().WithMessage("Unidade é obrigatória.")
                .MaximumLength(20).WithMessage("Unidade deve ter no máximo 20 caracteres.");

            RuleFor(x => x.EstoqueMinimo)
                .GreaterThanOrEqualTo(0).WithMessage("Estoque mínimo não pode ser negativo.");
        }
    }
}

