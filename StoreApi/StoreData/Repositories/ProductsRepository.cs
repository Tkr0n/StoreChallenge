using Domain.Entities;
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
    public class ProductsRepository(StoreContext context) : RepositoryBase<Product>(context), IProductsRepository
    {
        public async Task<IEnumerable<Product>> GetAll(Expression<Func<Product, bool>>? expression = null, bool? asNoTracking = false)
            => await Find(expression, asNoTracking).ToListAsync();
        public async Task<Product?> Get(Expression<Func<Product, bool>>? expression = null, bool? asNoTracking = false)
            => await Find(expression, asNoTracking).FirstOrDefaultAsync();

        public async Task<bool> Exists(Expression<Func<Product, bool>> expression)
            => await ExistsAsync(expression);
    }
}
