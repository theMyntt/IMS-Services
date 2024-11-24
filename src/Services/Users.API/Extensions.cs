using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Users.API.Context;
using Users.API.Repositories;
using Users.API.Repositories.Abstractions;
using Users.API.UseCases;
using Users.API.UseCases.Abstractions;

namespace Users.API;

public static class Extensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        var connection = Environment.GetEnvironmentVariable("USERS_MSSQL_CONN") ?? throw new Exception("USERS_MSSQL_CONN IS NOT SET");
        
        services.AddDbContext<DatabaseContext>(
            options => options.UseSqlServer(
                connection,
                m => m.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)));
        
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPermissionsRepository, PermissionsRepository>();
        
        return services;
    }

    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<ICreatePermissionUseCase, CreatePermissionUseCase>();
        services.AddScoped<IEditPermissionUseCase, EditPermissionUseCase>();
        services.AddScoped<IDeletePermissionUseCase, DeletePermissionUseCase>();
        
        return services;
    }
}