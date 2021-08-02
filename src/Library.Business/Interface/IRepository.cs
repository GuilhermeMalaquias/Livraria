using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Library.Business.Models;

namespace Library.Business.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        /*
         * Uso de interfaces para forçar a implementação de um "Contrato".
         * Uso de Task para manter o desenvolvimento da aplicação sem assincrona.
         */
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetById(Guid id);
        Task<List<TEntity>> GetAll();
        
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(Guid id);
        
        Task<int> SaveChanges();
    }
}