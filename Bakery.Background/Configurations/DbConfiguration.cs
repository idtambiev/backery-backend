using Bakery.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bakery.Background.Configurations
{
    public static class DbConfiguration
    {
        public static IServiceCollection Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BackeryDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Bakery.DataAccess"));
            },
            ServiceLifetime.Scoped);

            return services;
        }
    }
}
