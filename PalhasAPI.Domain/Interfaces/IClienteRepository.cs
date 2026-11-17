using PalhasAPI.Domain.Entities;

namespace PalhasAPI.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task AddAsync(Cliente cliente, CancellationToken cancellationToken);
        Task<Cliente?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
        Task UpdateAsync(Cliente cliente, CancellationToken cancellationToken);
        Task <List<Cliente>> GetAllAsync(string? filtro, CancellationToken cancellationToken);
    }
}
