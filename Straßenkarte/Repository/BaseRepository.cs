using Microsoft.EntityFrameworkCore;
using Straßenkarte.Abstract;
using Straßenkarte.Abstract.Repository;
using Straßenkarte.Enitites.ContextSınıfı;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Straßenkarte.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class,IEntity
    {
        private readonly AppDbContext dbContext;

        public BaseRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            dbContext.SaveChanges();

        }

        public IQueryable<T> GetAll()
        {
            return dbContext.Set<T>().AsNoTracking();
        }

        public T GetById(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public IQueryable<T> GetEx(Expression<Func<T, bool>> predicate)
        {
            return dbContext.Set<T>().Where(predicate).AsNoTracking();
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
            dbContext.SaveChanges();

        }
    }
}
