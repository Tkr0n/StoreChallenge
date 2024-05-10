using Domain.Entities;
using Domain.Repositories;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    public class CartByUserRepository(StoreContext context) : RepositoryBase<CartByUser>(context), ICartByUsersRepository
    {
        public async Task Create(CartByUser entity)
            => await Add(entity);

        public void Delete(CartByUser entity)
            => Remove(entity);

        public void Update(CartByUser entity)
            => Edit(entity);

        public async Task<CartByUser?> Get(Expression<Func<CartByUser, bool>>? expression = null, bool? asNoTracking = false)
            => await Find(expression, asNoTracking).FirstOrDefaultAsync();

        public async Task<bool> Exists(Expression<Func<CartByUser, bool>> expression)
            => await ExistsAsync(expression);
    }
}
