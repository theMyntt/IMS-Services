using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Users.API.Context;

namespace Users.API;

public static class Extensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        var connection = Environment.GetEnvironmentVariable("USERS_MSSQL_CONN") ?? throw new Exception("USERS_MSSQL_CONN IS NOT SET");
        
        services.AddDbContext<DatabaseContext>(
            options => options.UseSqlServer(
                m => m.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)));
        
        return services;
    }
}