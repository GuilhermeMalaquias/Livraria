using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Library.Business.Interface;
using Library.Business.Models;
using Library.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repository
{
    public abstract class Repository<TEntity>: IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly LibraryDbContext _db;
        protected readonly DbSet<TEntity> _dbSet;
        /*
         * Implementando o repositório genérico. Evitando código repetitivo
         */
        protected Repository(LibraryDbContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }
        public virtual async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.AsNoTracking().Where(expression).ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task Create(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Delete(Guid id)
        {
            _dbSet.Remove(new TEntity {Id = id});
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }

    }
}