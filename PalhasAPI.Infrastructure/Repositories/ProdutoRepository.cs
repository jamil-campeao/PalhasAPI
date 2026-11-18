
using Microsoft.EntityFrameworkCore;
using PalhasAPI.Domain.Entities;
using PalhasAPI.Domain.Interfaces;
using PalhasAPI.Infrastructure.Persistence;

namespace PalhasAPI.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly PalhasDbContext _context;

        public ProdutoRepository(PalhasDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Produto produto, CancellationToken cancellationToken)
        {
            await _context.Produtos.AddAsync(produto, cancellationToken);
        }

        public async Task<Produto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<List<Produto>> GetAllAsync(string? filtro, CancellationToken cancellationToken)
        {
            var query = _context.Produtos.Where(p => p.Ativo).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query = query.Where(p => p.Nome.Contains(filtro));
            }

            return await query.ToListAsync(cancellationToken);

        }

        public Task UpdateAsync(Produto produto, CancellationToken cancellationToken)
        {
            _context.Produtos.Update(produto);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
