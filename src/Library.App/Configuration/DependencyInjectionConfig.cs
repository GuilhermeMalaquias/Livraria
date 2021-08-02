using Library.App.Extension;
using Library.Business.Interface;
using Library.Data.Context;
using Library.Data.Repository;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;

namespace Library.App.Configuration
{
    public static class DependencyInjectionConfig
    {
        /*
         * Organizando a aplicação
         */
        public static IServiceCollection DependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<LibraryDbContext>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddSingleton<IValidationAttributeAdapterProvider, CurrencyAttributeAdapterProvider>();
            return services;
        }
    }
}