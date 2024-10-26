using auth_api.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace auth_api.Config;

public static class DatabaseConfiguration
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        connectionString = connectionString?.Replace("{DB_USERNAME}",
            Environment.GetEnvironmentVariable("DB_USERNAME") ?? "postgres");
        connectionString = connectionString?.Replace("{DB_PASSWORD}",
            Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "postgres");
        connectionString =
            connectionString?.Replace("{DB_HOST}", Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost");
        connectionString =
            connectionString?.Replace("{DB_PORT}", Environment.GetEnvironmentVariable("DB_PORT") ?? "5431");
        connectionString =connectionString?.Replace("{DB_NAME}", Environment.GetEnvironmentVariable("DB_NAME") ?? "auth_cs_api");

        services.AddDbContext<PostgresContext>(options => options.UseNpgsql(connectionString));
        services.AddDatabaseDeveloperPageExceptionFilter();
    }
}