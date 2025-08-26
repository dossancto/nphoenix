using PhoenixApi.Modules.Commum.Configuration.Databases;

namespace PhoenixApi.Modules.Commum;

public static class CommumModule
{
    public static IServiceCollection AddCommumModule(this IServiceCollection services)
    {
        services.AddDatabaseConfiguration();

        return services;
    }
}