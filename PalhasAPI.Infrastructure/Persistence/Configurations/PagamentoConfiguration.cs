using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PalhasAPI.Domain.Entities;

namespace PalhasAPI.Infrastructure.Persistence.Configurations
{
    public class PagamentoConfiguration : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Valor).HasColumnType("decimal(18,2)");

            builder.Property(p => p.Forma)
                .HasConversion<string>();

            builder.Property(p => p.Status)
                .HasConversion<string>();
        }
    }
}
