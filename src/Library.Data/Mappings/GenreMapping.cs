using Library.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Mappings
{
    public class GenreMapping : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            /*
             * Definindo propriedades para o banco de dados.
             */
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(g => g.Description)
                .IsRequired()
                .HasColumnType("varchar(300)");

            builder.ToTable("Genres");
        }
    }
}