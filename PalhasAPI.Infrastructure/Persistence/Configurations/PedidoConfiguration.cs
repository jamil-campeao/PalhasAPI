
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PalhasAPI.Domain.Entities;

namespace PalhasAPI.Infrastructure.Persistence.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Numero)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasIndex(p => p.Numero).IsUnique();

            builder.Property(p => p.Subtotal).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Desconto).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Total).HasColumnType("decimal(18,2)");

            builder.Property(p => p.Status)
                .HasConversion<string>();

            builder.Property(p => p.Observacoes).HasMaxLength(500);

            builder.HasMany(p => p.Itens)
                .WithOne(i => i.Pedido)
                .HasForeignKey(i => i.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Pagamentos)
                .WithOne(pg => pg.Pedido)
                .HasForeignKey(pg => pg.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
