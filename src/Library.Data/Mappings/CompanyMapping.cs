using Library.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Mappings
{
    public class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            /*
             * Definindo propriedades para o banco de dados.
             */
            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Document)
                .IsRequired()
                .HasColumnType("varchar(14)");
            
            builder.ToTable("Companies");
        }
    }
}