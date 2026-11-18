using MediatR;

namespace PalhasAPI.Application.Produtos.Commands.AtualizarProduto
{
    public record AtualizarProdutoCommand(
        Guid Id,
        string Nome,
        string? Descricao,
        decimal PrecoVenda,
        decimal CustoProducao,
        string Unidade,
        int EstoqueMinimo
        ) : IRequest;
}
