using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Person.Bootstrap
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration config)
        {
            services.AddMvc().AddJsonOptions(options => { options.JsonSerializerOptions.IgnoreNullValues = true; }).AddFluentValidation();
            services.ConfigureMediator();
            services.ConfigureSwagger();
            services.ConfigureRepositories(config);
            services.ConfigureValidators();
        }
    }
}
