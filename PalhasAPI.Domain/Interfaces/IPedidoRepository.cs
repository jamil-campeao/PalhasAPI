using PalhasAPI.Domain.Entities;

namespace PalhasAPI.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        Task AddAsync(Pedido pedido, CancellationToken cancellationToken);
        Task<Pedido?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Pedido>> GetAllAsync(CancellationToken cancellationToken);
        Task UpdateAsync(Pedido pedido, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
