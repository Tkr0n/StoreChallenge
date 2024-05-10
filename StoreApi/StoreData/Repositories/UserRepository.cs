using Domain.Entities;
using Domain.Repositories;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    public class UserRepository(StoreContext context) : RepositoryBase<User>(context), IUserRepository
    {
        public async Task Create(User entity)
            => await Add(entity);

        public void Delete(User entity)
            => Remove(entity);

        public void Update(User entity)
            => Edit(entity);

        public async Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>>? expression = null, bool? asNoTracking = false)
            => await Find(expression, asNoTracking).ToListAsync();
        public async Task<User?> Get(Expression<Func<User, bool>>? expression = null, bool? asNoTracking = false)
            => await Find(expression, asNoTracking).FirstOrDefaultAsync();

        public async Task<bool> Exists(Expression<Func<User, bool>> expression)
            => await ExistsAsync(expression);
    }
}
