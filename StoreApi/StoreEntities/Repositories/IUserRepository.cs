using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>>? expression = null, bool? asNoTracking = false);
        Task<User?> Get(Expression<Func<User, bool>> expression, bool? asNoTracking = false);
        Task Create(User entity);
        void Delete(User entity);
        void Update(User entity);
        Task<bool> Exists(Expression<Func<User, bool>> expression);
    }
}
