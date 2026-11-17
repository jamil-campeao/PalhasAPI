using Microsoft.EntityFrameworkCore;
using PalhasAPI.Domain.Entities;

namespace PalhasAPI.Infrastructure.Persistence
{
    public class PalhasDbContext : DbContext
    {
        public PalhasDbContext(DbContextOptions<PalhasDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Produto> Produtos => Set<Produto>();

        public DbSet<Pedido> Pedidos => Set<Pedido>();
        public DbSet<ItemPedido> ItensPedido => Set<ItemPedido>();
        public DbSet<Pagamento> Pagamentos => Set<Pagamento>();
        public DbSet<MovimentacaoEstoque> MovimentacoesEstoque => Set<MovimentacaoEstoque>();
        public DbSet<ContaFinanceira> ContasFinanceiras => Set<ContaFinanceira>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PalhasDbContext).Assembly);
                base.OnModelCreating(modelBuilder);
        }
    }
}
