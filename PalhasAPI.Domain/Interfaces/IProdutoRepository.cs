

using PalhasAPI.Domain.Entities;

namespace PalhasAPI.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task AddAsync(Produto produto, CancellationToken cancellationToken);
        Task<Produto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Produto>> GetAllAsync(string? filtro, CancellationToken cancellationToken);
        Task UpdateAsync(Produto produto, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
