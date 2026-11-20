

using MediatR;
using PalhasAPI.Application.Estoque.DTOs;

namespace PalhasAPI.Application.Estoque.Queries.ListarMovimentacoes
{
    public record ListarMovimentacoesQuery(Guid? ProdutoId = null) : 
        IRequest<List<MovimentacaoDto>>;
}
