

using Microsoft.EntityFrameworkCore;
using PalhasAPI.Domain.Entities;
using PalhasAPI.Domain.Interfaces;
using PalhasAPI.Infrastructure.Persistence;

namespace PalhasAPI.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PalhasDbContext _context;

        public PedidoRepository(PalhasDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Pedido pedido, CancellationToken cancellationToken)
        {
            await _context.Pedidos.AddAsync(pedido, cancellationToken);
        }

        public async Task<Pedido?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Pedidos
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Produto)
                .Include(p => p.Pagamentos)
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }



        public async Task<List<Pedido>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Produto)
                .OrderByDescending(p => p.CriadoEm)
                .ToListAsync(cancellationToken);
        }


        public Task UpdateAsync(Pedido pedido, CancellationToken cancellationToken)
        {
            _context.Pedidos.Update(pedido);
            return Task.CompletedTask;
        }


        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
