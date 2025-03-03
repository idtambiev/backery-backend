﻿using AutoMapper;
using Bakery.DataAccess.IOC;
using Bakery.Services.AutoMapper;
using Bakery.Services.Interfaces;
using Bakery.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Services.IOC
{
    public class ServicesConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            DataAccessConfiguration.Configure(services, configuration);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddTransient<IBunService, BunService>();
        } 
    }
}
