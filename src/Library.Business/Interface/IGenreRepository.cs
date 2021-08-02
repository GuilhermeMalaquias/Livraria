using System;
using System.Threading.Tasks;
using Library.Business.Models;

namespace Library.Business.Interface
{
    public interface IGenreRepository : IRepository<Genre>
    {
        /*
          * Definindo campos personalizados para cada entidade.
        * Uso de interfaces para forçar a implementação de um "Contrato".
        * Uso de Task para manter o desenvolvimento da aplicação sem assincrona.
        */
        Task<Genre> GetGenreBooks(Guid id);
    }
}