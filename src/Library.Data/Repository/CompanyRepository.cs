using System;
using System.Threading.Tasks;
using Library.Business.Interface;
using Library.Business.Models;
using Library.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(LibraryDbContext db) : base(db) { }

        public async Task<Company> GetCompanyBooks(Guid id)
        {
            return await _db.Companies
                .AsNoTracking()
                .Include(g => g.Books)
                .FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}