using MediatR;

namespace PalhasAPI.Application.Produtos.Commands.CriarProduto
{
    public record CriarProdutoCommand(
        string Nome,
        string? Descricao,
        decimal PrecoVenda,
        decimal CustoProducao,
        string Unidade,
        int EstoqueMinimo
        ) : IRequest<Guid>;
}
