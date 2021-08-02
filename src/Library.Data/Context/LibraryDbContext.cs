using System;
using System.Linq;
using Library.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Context
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> context): base(context){}
        
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Company> Companies { get; set; }

        /*
         *Garantindo que todas as propiedades do tipo string que não foram especificadas
         * um tamanho e tipo entre varchar ou "nvarchar(max) - (sqlserver) - valor default do AspNet Core"
         * receba sempre varchar(100).
         *
         *
         * Evitando a exclusão em modo cascata das entidades relacionadas.
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = Guid.Parse("7C022886-4877-419A-94C3-824FB7AEE950"),
                    Name = "Harvey Deitel",
                    About =
                        "Dr. Harvey M. Deitel, presidente e diretor de estratégia da Deitel & Associates, Inc., tem 45 anos de experiência acadêmica e industrial na área de informática. Dr. Deitel recebeu B.S. e M.S. graus do MIT e um Ph.D. da Boston University.",
                    Document = "07927830007",
                    TypePerson = TypePerson.PhysicalPerson

                },
                new Author
                {
                    Id = Guid.Parse("CA7329E9-DEDE-42EE-9A04-B372BD902751"),
                    Name = "Luciano Ramalho",
                    About = "Luciano Ramalho é programador Python desde 1998, Fellow da Python Software Foundation; é sócio do Python.pro.br – uma empresa de treinamento – e cofundador do Garoa Hacker Clube, o primeiro hackerspace do Brasil.",
                    Document = "06057967003",
                    TypePerson = TypePerson.PhysicalPerson

                },
                new Author
                    {
                        Id = Guid.Parse("1E221DA8-5000-446B-9477-4F67CD2FCE7A"),
                        Name = "Robert Cecil Martin",
                        About = "Robert Cecil Martin, também conhecido como Uncle Bob, é uma grande personalidade da comunidade de desenvolvimento de software, métodos ágeis e software craftsmanship, atuando na área desde 1970.",
                        Document = "54935366000181",
                        TypePerson = TypePerson.LegalPerson
                    }
                );

            modelBuilder.Entity<Genre>().HasData(

                new Genre
                {
                    Id = Guid.Parse("640A79E8-A4AC-472D-8086-59773836D907"),
                    Name = "Tecnologia",
                    Description = "Tecnologia é o conjunto de técnicas, habilidades, métodos e processos usados na produção de bens ou serviços, ou na realização de objetivos, como em investigações científicas."
                }
            );
            modelBuilder.Entity<Company>().HasData(
                
                new Company
                {
                    Id = Guid.Parse("59C5A2C3-D45C-481A-855D-8ABC2904C95F"),
                    Name = "Novatec Editora",
                    TypePerson = TypePerson.LegalPerson,
                    Document = "00591191000103"
                },
                new Company
                {
                    Id = Guid.Parse("A507CE21-F383-41D6-A583-D596ADC80BB3"),
                    Name = "Pearson Universidades",
                    TypePerson = TypePerson.LegalPerson,
                    Document = "01404158001838"
                },
                new Company
                {
                    Id = Guid.Parse("1E255A90-D95B-4164-BF01-8BD7CDAE040B"),
                    Name = "Alta Books",
                    TypePerson = TypePerson.LegalPerson,
                    Document = "51319823000115"
                }

                );
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "C#: Como Programar",
                    Image = "906708E8-3F62-4626-8514-DF9EAC682460_image.jpg",
                    ISBN = "9788534614597",
                    PublicationDate = DateTime.Now,
                    Price = 150,
                    Active = true,
                    Description = "O Autor explica neste livro, como usar a linguagem de programação C# a principal linguagem na iniciativa .NET da Microsoft para programação de propósito geral e para desenvolver aplicativos multicamadas, cliente-servidor, com uso intensivo de banco de dados, baseados na Internet e na Web.",
                    AuthorId = Guid.Parse("7C022886-4877-419A-94C3-824FB7AEE950"),
                    GenreId = Guid.Parse("640A79E8-A4AC-472D-8086-59773836D907"),
                    CompanyId = Guid.Parse("A507CE21-F383-41D6-A583-D596ADC80BB3")
                    
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Python Fluente",
                    Image = "52557B29-C28C-4866-A08D-D0C00526E921_PythonFluente.jpg",
                    ISBN = "9788575224625",
                    PublicationDate = DateTime.Now,
                    Price = 115,
                    Active = true,
                    Description = "A simplicidade de Python permite que você se torne produtivo rapidamente, porém isso muitas vezes significa que você não estará usando tudo que ela tem a oferecer. Com este guia prático, você aprenderá a escrever um código Python eficiente e idiomático aproveitando seus melhores recursos",
                    AuthorId = Guid.Parse("CA7329E9-DEDE-42EE-9A04-B372BD902751"),
                    GenreId = Guid.Parse("640A79E8-A4AC-472D-8086-59773836D907"),
                    CompanyId = Guid.Parse("59C5A2C3-D45C-481A-855D-8ABC2904C95F")

                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Código limpo",
                    Image = "0DBC0E1F-C13B-430E-9A11-65C1A669FAEA_CleanCode.jpg",
                    ISBN = "9788576082675",
                    PublicationDate = DateTime.Now,
                    Price = 75,
                    Active = false,
                    Description = "Mesmo um código ruim pode funcionar. Mas se ele não for limpo, pode acabar com uma empresa de desenvolvimento. Perdem-se a cada ano horas incontáveis e recursos importantes devido a um código mal escrito. Mas não precisa ser assim.",
                    AuthorId = Guid.Parse("1E221DA8-5000-446B-9477-4F67CD2FCE7A"),
                    GenreId = Guid.Parse("640A79E8-A4AC-472D-8086-59773836D907"),
                    CompanyId = Guid.Parse("1E255A90-D95B-4164-BF01-8BD7CDAE040B")
                }
                );
        }
        
    }
}