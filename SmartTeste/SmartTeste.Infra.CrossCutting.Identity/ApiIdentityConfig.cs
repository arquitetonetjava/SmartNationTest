﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SmartTeste.Infra.CrossCutting.Identity
{
    public static class ApiIdentityConfig
    {
        public static void AddApiIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // Default EF Context for Identity (inside of the NetDevPack.Identity)
            services.AddIdentityEntityFrameworkContextConfiguration(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("SmartTeste.Infra.CrossCutting.Identity")));

            // Default Identity configuration from NetDevPack.Identity
            services.AddIdentityConfiguration();

            // Default JWT configuration from NetDevPack.Identity
            // services.AddJwtConfiguration(configuration, "AppSettings");
        }
    }
}
