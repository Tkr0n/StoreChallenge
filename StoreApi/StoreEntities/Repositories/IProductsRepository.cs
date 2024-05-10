using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<Product>> GetAll(Expression<Func<Product, bool>>? expression = null, bool? asNoTracking = false);
        public Task<Product> Get(Expression<Func<Product, bool>>? expression = null, bool? asNoTracking = false);
        public Task<bool> Exists(Expression<Func<Product, bool>>? expression = null);
    }
}
