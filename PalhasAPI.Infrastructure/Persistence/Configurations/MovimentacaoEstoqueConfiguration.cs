

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PalhasAPI.Domain.Entities;

namespace PalhasAPI.Infrastructure.Persistence.Configurations
{
    public class MovimentacaoEstoqueConfiguration : IEntityTypeConfiguration<MovimentacaoEstoque>
    {
        public void Configure(EntityTypeBuilder<MovimentacaoEstoque> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Motivo).IsRequired().HasMaxLength(200);

            builder.Property(m => m.Tipo)
                .HasConversion<string>();

            builder.HasOne(m => m.Produto)
                .WithMany(p => p.Movimentacoes)
                .HasForeignKey(m => m.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
