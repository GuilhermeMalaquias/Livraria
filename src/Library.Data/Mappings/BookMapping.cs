using Library.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Mappings
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            /*
             * Definindo propriedades para o banco de dados.
             */
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)  
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(b => b.Description)
                .IsRequired()
                .HasColumnType("varchar(300)");
            
            builder.Property(b => b.ISBN)
                .IsRequired()
                .HasColumnType("varchar(13)");

            builder.Property(b => b.Image)
                .IsRequired()
                .HasColumnType("varchar(100)");
            
            builder.Property(b => b.Price)
                .IsRequired()
                .HasColumnType("decimal(8,2)");


            builder.HasOne(b => b.Author)
                .WithMany(b => b.Books)
                .HasForeignKey(b => b.AuthorId);
            
            builder.HasOne(b => b.Company)
                .WithMany(b => b.Books)
                .HasForeignKey(b => b.CompanyId);
            
            builder.HasOne(b => b.Genre)
                .WithMany(b => b.Books)
                .HasForeignKey(b => b.GenreId);

            builder.ToTable("Books");
        }
    }
}