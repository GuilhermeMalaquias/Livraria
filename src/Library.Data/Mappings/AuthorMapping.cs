using Library.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Mappings
{
    public class AuthorMapping : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            /*
             * Definindo propriedades para o banco de dados.
             */
            builder.HasKey(b => b.Id);

            builder.Property(a => a.Name)  
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(a => a.About)
                .IsRequired()
                .HasColumnType("varchar(300)");
            
            builder.Property(b => b.Document)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.ToTable("Authors");
        }
    }
}