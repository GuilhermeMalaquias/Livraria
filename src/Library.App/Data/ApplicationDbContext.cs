using Library.App.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.App.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUserCustom>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       
    }
}