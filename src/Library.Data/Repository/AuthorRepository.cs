using System;
using System.Threading.Tasks;
using Library.Business.Interface;
using Library.Business.Models;
using Library.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repository
{
    public class AuthorRepository: Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryDbContext db) : base(db){ }

        public async Task<Author> GetAuthorBooks(Guid id)
        {
            return await _db.Authors
                .AsNoTracking()
                .Include(g => g.Books)
                .FirstOrDefaultAsync(a => a.Id == id);

        }
    }
}