using System;
using System.Linq;
using System.Linq.Expressions;

namespace Straßenkarte.Abstract.Repository
{
    public interface IRepository<T> where T : class, IEntity
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        IQueryable<T> GetEx(Expression<Func<T, bool>> predicate);

    }
}
