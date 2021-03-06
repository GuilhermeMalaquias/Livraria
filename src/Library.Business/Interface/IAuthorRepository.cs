using System;
using System.Threading.Tasks;
using Library.Business.Models;

namespace Library.Business.Interface
{
    public interface IAuthorRepository : IRepository<Author>
    {
        /*
         * Definindo campos personalizados para cada entidade.
       * Uso de interfaces para for?ar a implementa??o de um "Contrato".
       * Uso de Task para manter o desenvolvimento da aplica??o sem assincrona.
       */
        Task<Author> GetAuthorBooks(Guid id);
    }
}