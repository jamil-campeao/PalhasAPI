using Microsoft.EntityFrameworkCore;
using PalhasAPI.Domain.Entities;
using PalhasAPI.Domain.Interfaces;
using PalhasAPI.Infrastructure.Persistence;

namespace PalhasAPI.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly PalhasDbContext _context;

        public ClienteRepository(PalhasDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Cliente cliente, CancellationToken cancellationToken)
        {
            await _context.Clientes.AddAsync(cliente, cancellationToken);
        }

        public async Task<Cliente?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public Task UpdateAsync (Cliente cliente, CancellationToken cancellationToken)
        {
            _context.Clientes.Update(cliente);
            return Task.CompletedTask;
        }

        public async Task<List<Cliente>> GetAllAsync(string? filtro, CancellationToken cancellationToken)
        {
            var query = _context.Clientes.Where(c => c.Ativo).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query = query.Where(c => c.Nome.Contains(filtro) || c.Telefone!.Contains(filtro));
            }

            return await query.ToListAsync(cancellationToken);
        }

    }
}
