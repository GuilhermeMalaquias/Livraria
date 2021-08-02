using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Business.Interface;
using Library.Business.Models;
using Library.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryDbContext db) : base(db) { }
        //Buscando um livro e incluindo sua dependências de models e retornando
        //e verificando se tem privilégios para ver livros não disponíveis
        //Usando o AsNoTracking para ganho de performance -- referencia: https://medium.com/@alexandre.malavasi/dica-rápida-asnotracking-entity-framework-core-ab3754df792a
        public async Task<IEnumerable<Book>> GetBooksAuthorsGenresCompanies(bool isAdminOrManager)
        {
            if (isAdminOrManager)
            {
                return await _db.Books
                    .AsNoTracking()
                    .Include(b => b.Author)
                    .Include(b => b.Genre)
                    .Include(b => b.Company)
                    .OrderBy(b => b.Title)
                    .ToListAsync();
            }
            return await _db.Books
                .AsNoTracking()
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .Include(b => b.Company)
                .Where(b => b.Active == true)
                .OrderBy(b => b.Title)
                .ToListAsync();
        }
        //Buscando livro de forma decrescente e verificando se tem privilégios para ver livros não disponíveis
        public async Task<IEnumerable<Book>> GetBooksAuthorsGenresCompaniesDecreasing(bool isAdminOrManager)
        {
            if (isAdminOrManager)
            {
                return await _db.Books
                    .AsNoTracking()
                    .Include(b => b.Author)
                    .Include(b => b.Genre)
                    .Include(b => b.Company)
                    .OrderByDescending(b => b.Title)
                    .ToListAsync();
            }
            return await _db.Books
                .AsNoTracking()
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .Include(b => b.Company)
                .Where(b => b.Active == true)
                .OrderByDescending(b => b.Title)
                .ToListAsync();

        }
        //Buscando um livro e incluindo sua dependências de models e retornando 
        //Usando FirstOrDefault a fim de evitar uma exception caso encontre mais de um resultado.
        public async Task<Book> GetBookAuthorsGenresCompanies(Guid id)
        {
            return await _db.Books
                .AsNoTracking()
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .Include(b => b.Company)
                .OrderBy(b => b.Title)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
        //Buscando livro a partir de um termo e verificando se tem privilégios para ver livros não disponíveis
        public async Task<IEnumerable<Book>> FindBook(string findTerm, bool isAdminOrManager)
        {
            if (isAdminOrManager)
            {
                return await _db.Books
                    .AsNoTracking()
                    .Include(b => b.Author)
                    .Include(b => b.Genre)
                    .Include(b => b.Company)
                    .Where(b => b.Title.Contains(findTerm) ||
                                b.Author.Name.Contains(findTerm) ||
                                b.Genre.Name.Contains(findTerm) ||
                                b.Company.Name.Contains(findTerm))
                    .ToListAsync();
            }
            return await _db.Books
                .AsNoTracking()
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .Include(b => b.Company)
                .Where(b => b.Active == true)
                .Where(b => b.Title.Contains(findTerm) ||
                            b.Author.Name.Contains(findTerm) ||
                            b.Genre.Name.Contains(findTerm) ||
                            b.Company.Name.Contains(findTerm))
                .ToListAsync();


        }
    }
}