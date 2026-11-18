
using MediatR;
using PalhasAPI.Application.Produtos.DTOs;

namespace PalhasAPI.Application.Produtos.Queries.ListarProdutos
{
    public record ListarProdutosQuery(string? Filtro = null) : IRequest<List<ProdutoDto>>;
}
