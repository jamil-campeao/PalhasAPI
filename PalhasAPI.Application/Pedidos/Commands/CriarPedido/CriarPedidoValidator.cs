using FluentValidation;

namespace PalhasAPI.Application.Pedidos.Commands.CriarPedido
{
    public class CriarPedidoValidator : AbstractValidator<CriarPedidoCommand>
    {
        public CriarPedidoValidator()
        {
            RuleFor(x => x.ClienteId)
                .NotEmpty().WithMessage("ClienteId é obrigatório.");

            RuleFor(x => x.Itens)
                .NotEmpty().WithMessage("O pedido deve ter ao menos um item.");

            RuleForEach(x => x.Itens).ChildRules(item =>
            {
                item.RuleFor(x => x.ProdutoId)
                    .NotEmpty().WithMessage("ProdutoId do item é obrigatório.");

                item.RuleFor(x => x.Quantidade)
                    .GreaterThan(0).WithMessage("Quantidade do item deve ser maior que zero.");
            });

            RuleFor(x => x.Desconto)
                .GreaterThanOrEqualTo(0).WithMessage("Desconto não pode ser negativo.");
        }
    }
}
