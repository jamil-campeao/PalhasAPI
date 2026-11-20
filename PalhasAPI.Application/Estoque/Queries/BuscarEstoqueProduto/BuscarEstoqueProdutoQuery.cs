

using MediatR;
using PalhasAPI.Application.Estoque.DTOs;

namespace PalhasAPI.Application.Estoque.Queries.BuscarEstoqueProduto
{
    public record BuscarEstoqueProdutoQuery(Guid ProdutoId) :
        IRequest<EstoqueProdutoDto?>;
}
