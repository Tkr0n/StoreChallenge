using Domain.Repositories;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class RepositoryBase<T>(StoreContext context) : IRepositoryBase<T> where T : class
    {
        private readonly StoreContext _context = context;

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression) =>
            await _context.Set<T>().AsNoTracking().AnyAsync(expression);

        public Task UpdateRange(IEnumerable<T> entityList)
        {
            _context.Set<T>().UpdateRange(entityList);
            return Task.CompletedTask;
        }

        public Task RemoveRange(IEnumerable<T> entityList)
        {
            _context.Set<T>().RemoveRange(entityList);
            return Task.CompletedTask;
        }

        public async Task AddRange(IEnumerable<T> entityList) => await _context.Set<T>().AddRangeAsync(entityList);

        public async Task Add(T entity) => await _context.Set<T>().AddAsync(entity);

        public IQueryable<T> Find(Expression<Func<T, bool>>? expression = null, bool? asNoTracking = false)
        {
            var query = _context.Set<T>().AsQueryable();

            if (expression is not null)
                query = query.Where(expression);

            if (asNoTracking is true)
                query = query.AsNoTracking();

            return query;

        }

        public void Remove(T entity) => _context.Set<T>().Remove(entity);

        public void Edit(T entity) => _context.Set<T>().Update(entity);

    }
}
