

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PalhasAPI.Domain.Entities;

namespace PalhasAPI.Infrastructure.Persistence.Configurations
{
    public class ContaFinanceiraConfiguration : IEntityTypeConfiguration<ContaFinanceira>
    {
        public void Configure(EntityTypeBuilder<ContaFinanceira> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao).IsRequired().HasMaxLength(300);
            builder.Property(c => c.Valor).HasColumnType("decimal(18,2)");
            builder.Property(c => c.Categoria).HasMaxLength(100);

            builder.Property(c => c.Tipo)
                .HasConversion<string>();
        }
    }
}
