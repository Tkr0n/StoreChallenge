using Domain.Repositories;
using Infraestructure.Context;
using Infraestructure.Repositories;

namespace Infraestructure
{
    public class RepositoryManager: IRepositoryManager
    {
        private readonly StoreContext _context;
        private readonly Lazy<IUserRepository> _usersRepository;
        private readonly Lazy<IProductsRepository> _productsRepository;
        private readonly Lazy<ICartByUsersRepository> _cartsRepository;

        public RepositoryManager(StoreContext context) {

            _usersRepository = new Lazy<IUserRepository>(() => new UserRepository(context));
            //_productsRepository = new Lazy<IProductsRepository>(() => new ProductsRepository(context));
            //_cartsRepository = new Lazy<ICartByUsersRepository>(() => new CartByUsersRepository(context));
            _context = context;
        }

        public IUserRepository UsersRepository => _usersRepository.Value;

        //public IProductsRepository ProductsRepository => _productsRepository.Value;

        //public ICartByUsersRepository CartByUsersRepository => _cartsRepository.Value;

        public Task Commit() => _context.SaveChangesAsync();
    }
}
