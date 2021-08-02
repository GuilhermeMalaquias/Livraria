using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Data.Migrations
{
    public partial class AddModelsAndDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Document = table.Column<string>(type: "varchar(14)", nullable: false),
                    TypePerson = table.Column<int>(type: "int", nullable: false),
                    About = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Document = table.Column<string>(type: "varchar(14)", nullable: false),
                    TypePerson = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", nullable: false),
                    Image = table.Column<string>(type: "varchar(100)", nullable: false),
                    ISBN = table.Column<string>(type: "varchar(13)", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "varchar(300)", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "About", "Document", "Name", "TypePerson" },
                values: new object[,]
                {
                    { new Guid("7c022886-4877-419a-94c3-824fb7aee950"), "Dr. Harvey M. Deitel, presidente e diretor de estratégia da Deitel & Associates, Inc., tem 45 anos de experiência acadêmica e industrial na área de informática. Dr. Deitel recebeu B.S. e M.S. graus do MIT e um Ph.D. da Boston University.", "07927830007", "Harvey Deitel", 1 },
                    { new Guid("ca7329e9-dede-42ee-9a04-b372bd902751"), "Luciano Ramalho é programador Python desde 1998, Fellow da Python Software Foundation; é sócio do Python.pro.br – uma empresa de treinamento – e cofundador do Garoa Hacker Clube, o primeiro hackerspace do Brasil.", "06057967003", "Luciano Ramalho", 1 },
                    { new Guid("1e221da8-5000-446b-9477-4f67cd2fce7a"), "Robert Cecil Martin, também conhecido como Uncle Bob, é uma grande personalidade da comunidade de desenvolvimento de software, métodos ágeis e software craftsmanship, atuando na área desde 1970.", "54935366000181", "Robert Cecil Martin", 2 }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Document", "Name", "TypePerson" },
                values: new object[,]
                {
                    { new Guid("59c5a2c3-d45c-481a-855d-8abc2904c95f"), "00591191000103", "Novatec Editora", 2 },
                    { new Guid("a507ce21-f383-41d6-a583-d596adc80bb3"), "01404158001838", "Pearson Universidades", 2 },
                    { new Guid("1e255a90-d95b-4164-bf01-8bd7cdae040b"), "51319823000115", "Alta Books", 2 }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("640a79e8-a4ac-472d-8086-59773836d907"), "Tecnologia é o conjunto de técnicas, habilidades, métodos e processos usados na produção de bens ou serviços, ou na realização de objetivos, como em investigações científicas.", "Tecnologia" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Active", "AuthorId", "CompanyId", "Description", "GenreId", "ISBN", "Image", "Price", "PublicationDate", "Title" },
                values: new object[] { new Guid("14a8666b-908c-4915-86c2-6ee42b8ec80f"), true, new Guid("7c022886-4877-419a-94c3-824fb7aee950"), new Guid("a507ce21-f383-41d6-a583-d596adc80bb3"), "O Autor explica neste livro, como usar a linguagem de programação C# a principal linguagem na iniciativa .NET da Microsoft para programação de propósito geral e para desenvolver aplicativos multicamadas, cliente-servidor, com uso intensivo de banco de dados, baseados na Internet e na Web.", new Guid("640a79e8-a4ac-472d-8086-59773836d907"), "9788534614597", "906708E8-3F62-4626-8514-DF9EAC682460_image.jpg", 150m, new DateTime(2021, 8, 2, 10, 11, 1, 233, DateTimeKind.Local).AddTicks(8044), "C#: Como Programar" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Active", "AuthorId", "CompanyId", "Description", "GenreId", "ISBN", "Image", "Price", "PublicationDate", "Title" },
                values: new object[] { new Guid("6ac30476-7f85-43fe-9a48-bd6a583f89a3"), true, new Guid("ca7329e9-dede-42ee-9a04-b372bd902751"), new Guid("59c5a2c3-d45c-481a-855d-8abc2904c95f"), "A simplicidade de Python permite que você se torne produtivo rapidamente, porém isso muitas vezes significa que você não estará usando tudo que ela tem a oferecer. Com este guia prático, você aprenderá a escrever um código Python eficiente e idiomático aproveitando seus melhores recursos", new Guid("640a79e8-a4ac-472d-8086-59773836d907"), "9788575224625", "52557B29-C28C-4866-A08D-D0C00526E921_PythonFluente.jpg", 115m, new DateTime(2021, 8, 2, 10, 11, 1, 234, DateTimeKind.Local).AddTicks(8949), "Python Fluente" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Active", "AuthorId", "CompanyId", "Description", "GenreId", "ISBN", "Image", "Price", "PublicationDate", "Title" },
                values: new object[] { new Guid("22ff22c1-5acd-4a71-bd16-50376b706ccf"), false, new Guid("1e221da8-5000-446b-9477-4f67cd2fce7a"), new Guid("1e255a90-d95b-4164-bf01-8bd7cdae040b"), "Mesmo um código ruim pode funcionar. Mas se ele não for limpo, pode acabar com uma empresa de desenvolvimento. Perdem-se a cada ano horas incontáveis e recursos importantes devido a um código mal escrito. Mas não precisa ser assim.", new Guid("640a79e8-a4ac-472d-8086-59773836d907"), "9788576082675", "0DBC0E1F-C13B-430E-9A11-65C1A669FAEA_CleanCode.jpg", 75m, new DateTime(2021, 8, 2, 10, 11, 1, 234, DateTimeKind.Local).AddTicks(8988), "Código limpo" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CompanyId",
                table: "Books",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
