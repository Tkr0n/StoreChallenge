using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRepositoryManager
    {
        IUserRepository UsersRepository { get; }
        IProductsRepository ProductsRepository { get; }
        ICartByUsersRepository CartByUsersRepository { get; }
        Task Commit();
    }
}
