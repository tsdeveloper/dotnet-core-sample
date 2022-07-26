using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ParcelasConfiguration : IEntityTypeConfiguration<Parcela>
    {
        public void Configure(EntityTypeBuilder<Parcela> builder)
        {
           
            builder.Property(i => i.ValorParcela)
                .HasColumnType("decimal(18,2)");
            
            builder.HasOne(b => b.Financiamento)
                .WithMany(x => x.ListParcelas)
                .HasForeignKey(p => p.FinanciamentoId);
        }
    }
}