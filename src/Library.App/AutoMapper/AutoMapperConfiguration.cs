using AutoMapper;
using Library.App.ViewModels;
using Library.Business.Models;

namespace Library.App.AutoMapper
{
    public class AutoMapperConfiguration: Profile
    {
        public AutoMapperConfiguration()
        {
            /*
             * Convertendo o Model Author para AuthorViewModel e vice-versa
             */
            CreateMap<Author, AuthorViewModel>().ReverseMap();
            CreateMap<Book, BookViewModel>().ReverseMap();
            CreateMap<Company, CompanyViewModel>().ReverseMap();
            CreateMap<Genre, GenreViewModel>().ReverseMap();
        }
    }
}