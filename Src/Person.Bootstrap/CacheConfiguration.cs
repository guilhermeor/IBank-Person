using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Person.Bootstrap
{
    public static class CacheConfiguration
    {
        public static IServiceCollection CacheConfigurationServices(this IServiceCollection services, IConfiguration config)
        {
            var redisConnecttion = config.GetConnectionString("Redis");
            if (!string.IsNullOrEmpty(redisConnecttion))
            {
                services.AddDistributedRedisCache(options =>
                {
                    options.Configuration = redisConnecttion;
                    options.InstanceName = "person:";
                });
            }
            else
                services.AddDistributedMemoryCache();
            return services;

        }
    }
}
