using Amazon;
using Amazon.Runtime;

namespace SecretsManager.API.SecretsManager
{
    public static class SecretsManagerConfig
    {
        public static IConfigurationBuilder AddSecretsManagerConfiguration(this IConfigurationBuilder config, IConfiguration configuration, string environment)
        {
            var credentials = new BasicAWSCredentials(configuration["AWSCredentials:AccessKey"], configuration["AWSCredentials:SecretKey"]);

            config.AddSecretsManager(credentials, RegionEndpoint.USEast1, configurator: config =>
            {
                config.SecretFilter = entry => entry.Name.StartsWith($"API_{environment}_");
                config.KeyGenerator = (secret, name) => name
                        .Replace($"API_{environment}_", string.Empty)
                        .Replace("__", ":");
            });

            return config;
        }
    }
}
