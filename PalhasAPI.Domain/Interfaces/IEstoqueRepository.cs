

using PalhasAPI.Domain.Entities;

namespace PalhasAPI.Domain.Interfaces
{
    public interface IEstoqueRepository
    {
        Task AddAsync(MovimentacaoEstoque movimentacao, CancellationToken cancellationToken);
        Task<List<MovimentacaoEstoque>> GetAllAsync(Guid? produtoId, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
