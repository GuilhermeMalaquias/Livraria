using System;
using System.Threading.Tasks;
using Library.Business.Interface;
using Library.Business.Models;
using Library.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repository
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(LibraryDbContext db) : base(db) { }

        public async Task<Genre> GetGenreBooks(Guid id)
        {
            return await _db.Genres
                .AsNoTracking()
                .Include(g => g.Books)
                .FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}