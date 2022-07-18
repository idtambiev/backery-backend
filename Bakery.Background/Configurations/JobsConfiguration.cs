using Bakery.Background.Jobs;
using Bakery.Background.Quartz;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace Bakery.Background.Configurations
{
    public static class JobsConfiguration
    {
        public static IServiceCollection Configure(IServiceCollection services)
        {
            services
                .AddSingleton<IJobFactory, CustomJobFactory>()
                .AddSingleton<ISchedulerFactory, StdSchedulerFactory>();



            // "0 0 0/1 ? * * *" is for "every hour"
            services
                .AddSingleton<UpdatePricesJob>()
                .AddSingleton(new JobSchedule(
                    jobType: typeof(UpdatePricesJob),
                    //cronExpression: "0 0 0/1 ? * * *"
                    cronExpression: "0 0/1 0 ? * * *"
                ));

            services.AddHostedService<QuartzHostedService>();

            return services;
        }
    }
}
