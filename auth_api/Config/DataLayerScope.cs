using auth_api.Infra.DataLayer;

namespace auth_api.Config;

public static class DataLayerScope
{
    public static void AddDataLayerScopes(this IServiceCollection services)
    {
        services.AddScoped<UserDataLayer>();
    }
}
