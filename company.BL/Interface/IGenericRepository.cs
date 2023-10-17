using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepositoryUsingEFinMVC.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll(params Expression<Func<T , object>>[] expressionList);

         IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includeProperties);
       


        T GetById(object id, params Expression<Func<T, object>>[] expressionList);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}