﻿using Application.Common.DataAccess;
using DataAccess.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class ConfigureDependencies
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<IDbConnectionFactory>(_ =>
        new SqlConnectionFactory(config.GetConnectionString("DefaultConnection")!)) ;

        services.AddSingleton<DatabaseInitializer>();

        return services;
    }
}
