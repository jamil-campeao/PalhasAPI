using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PalhasAPI.Domain.Entities;

namespace PalhasAPI.Infrastructure.Persistence.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.Descricao).HasMaxLength(500);
            builder.Property(p => p.Unidade).IsRequired().HasMaxLength(20);

            builder.Property(p => p.PrecoVenda)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.CustoProducao)
                .HasColumnType("decimal(18,2)");
        }

    }
}
