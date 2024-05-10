using Domain.Entities;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Context
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<CartByUser> CartsByUser { get; set; }
    }
}
