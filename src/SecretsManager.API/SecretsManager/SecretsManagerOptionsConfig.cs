using SecretsManager.API.SecretsManager.Options;

namespace SecretsManager.API.SecretsManager
{
    public static class SecretsManagerOptionsConfig
    {
        public static IServiceCollection AddSecretsManagerOptionsConfiguration(this IServiceCollection services)
        {
            services.AddOptions<ConnectionStringsOptions>().BindConfiguration("ConnectionStrings");
            services.AddOptions<TokenConfigurationsOptions>().BindConfiguration("TokenConfigurations");

            return services;
        }
    }
}