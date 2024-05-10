using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> Find(Expression<Func<T, bool>>? expression = null, bool? asNoTracking = false);
        Task Add(T entity);
        void Edit(T entity);
        void Remove(T entity);
    }
}
