

using Microsoft.EntityFrameworkCore;
using PalhasAPI.Domain.Entities;
using PalhasAPI.Domain.Interfaces;
using PalhasAPI.Infrastructure.Persistence;

namespace PalhasAPI.Infrastructure.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly PalhasDbContext _context;

        public EstoqueRepository(PalhasDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MovimentacaoEstoque movimentacao, CancellationToken cancellationToken)
        {
            await _context.MovimentacoesEstoque.AddAsync(movimentacao, cancellationToken);
        }

        public async Task<List<MovimentacaoEstoque>> GetAllAsync(Guid? produtoId, CancellationToken cancellationToken)
        {
            var query = _context.MovimentacoesEstoque
                .Include(m => m.Produto)
                .AsQueryable();

            if (produtoId.HasValue)
            {
                query = query.Where(m => m.ProdutoId == produtoId);
            }

            return await query
                .OrderByDescending(m => m.CriadoEm)
                .ToListAsync(cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
