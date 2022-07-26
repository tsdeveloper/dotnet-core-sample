using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class FinanciamentoConfiguration : IEntityTypeConfiguration<Financiamento>
    {
        public void Configure(EntityTypeBuilder<Financiamento> builder)
        {
           
            builder.Property(i => i.ValorTotal)
                .HasColumnType("decimal(18,2)");
            
            builder.HasOne(b => b.Cliente)
                .WithMany(x => x.ListFinanciamentos)
                .HasForeignKey(p => p.ClienteId);
         
        }
    }
}