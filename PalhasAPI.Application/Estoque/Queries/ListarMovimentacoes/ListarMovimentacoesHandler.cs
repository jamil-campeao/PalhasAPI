

using MediatR;
using PalhasAPI.Application.Estoque.DTOs;
using PalhasAPI.Domain.Interfaces;

namespace PalhasAPI.Application.Estoque.Queries.ListarMovimentacoes
{
    public class ListarMovimentacoesHandler : IRequestHandler<ListarMovimentacoesQuery, List<MovimentacaoDto>>
    {
        private readonly IEstoqueRepository _respository;


        public ListarMovimentacoesHandler(IEstoqueRepository repository)
        {
            _respository = repository;
        }


        public async Task<List<MovimentacaoDto>> Handle(ListarMovimentacoesQuery request, CancellationToken cancellationToken)
        {
            var movimentacoes = await _respository.GetAllAsync(request.ProdutoId, cancellationToken);

            return movimentacoes.Select(m => new MovimentacaoDto
            {
                Id = m.Id,
                ProdutoId = m.ProdutoId,
                NomeProduto = m.Produto.Nome,
                Tipo = m.Tipo,
                Quantidade = m.Quantidade,
                Motivo = m.Motivo,
                CriadoEm = m.CriadoEm
            }).ToList();
        }
    }
}
