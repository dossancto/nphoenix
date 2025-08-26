using Microsoft.EntityFrameworkCore;

using PhoenixApi.Modules.Commum.Adapters.Databases;

namespace PhoenixApi.Modules.Commum.Configuration.Databases;

public static class DatabaseConfiguration
{
    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(AppEnv.DATABASES.SQLITE.DATASOURCE.NotNull());
        });

        return services;
    }
}