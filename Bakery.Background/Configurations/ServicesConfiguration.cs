using Bakery.Background.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bakery.Background.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection Configure(IServiceCollection services)
        {
            services.AddSingleton<IUpdatePricesService, UpdatePricesService>();
            return services;
        } 
    }
}
