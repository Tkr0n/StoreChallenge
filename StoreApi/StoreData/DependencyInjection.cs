using Domain.Repositories;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection SetupInfrastructureLayer(this IServiceCollection services, IConfiguration configuration, string connectionString)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddDbContext<StoreContext>(options =>
                options.UseSqlServer(connectionString,
                d => {
                    d.EnableRetryOnFailure();
                    d.MigrationsAssembly(assembly.FullName);
                }));

            services.AddScoped<IRepositoryManager, RepositoryManager>();

            return services;
        }
    }
}
