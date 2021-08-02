using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Business.Models;

namespace Library.Business.Interface
{
    public interface IBookRepository: IRepository<Book>
    {
        
        // Definindo campos personalizados para cada entidade.
        // Uso de interfaces para for�ar a implementa��o de um "Contrato".
        // Uso de Task para manter o desenvolvimento da aplica��o sem assincrona.
        Task<IEnumerable<Book>> FindBook(string findTerm, bool isAdminOrManager);
        Task<IEnumerable<Book>> GetBooksAuthorsGenresCompanies(bool isAdminOrManager);
        Task<IEnumerable<Book>> GetBooksAuthorsGenresCompaniesDecreasing(bool isAdminOrManager);
        Task<Book> GetBookAuthorsGenresCompanies(Guid id);
    }
}