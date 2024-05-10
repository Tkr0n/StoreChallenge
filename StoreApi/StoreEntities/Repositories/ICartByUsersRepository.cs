using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICartByUsersRepository
    {
        public Task Create(CartByUser entity);

        public void Delete(CartByUser entity);

        public void Update(CartByUser entity);

        public Task<CartByUser?> Get(Expression<Func<CartByUser, bool>>? expression = null, bool? asNoTracking = false);

        public Task<bool> Exists(Expression<Func<CartByUser, bool>> expression);
    }
}
