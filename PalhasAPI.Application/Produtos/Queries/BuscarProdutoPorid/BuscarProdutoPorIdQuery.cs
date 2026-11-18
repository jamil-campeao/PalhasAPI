

using MediatR;
using PalhasAPI.Application.Produtos.DTOs;

namespace PalhasAPI.Application.Produtos.Queries.BuscarProdutoPorid
{
    public record BuscarProdutoPorIdQuery(Guid Id) : IRequest<ProdutoDto?>;
}
