using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class EmprestimosConfiguration : IEntityTypeConfiguration<Emprestimos>
    {
        public void Configure(EntityTypeBuilder<Emprestimos> builder)
        {
           
            builder.Property(i => i.CreditValue)
                .HasColumnType("decimal(18,2)");
         
        }
    }
}