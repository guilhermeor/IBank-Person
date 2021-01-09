using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Person.Bootstrap
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IBank-Person", Version = "v1" });
            });
            return services;
        }
        public static IApplicationBuilder ConfigurationSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DisplayRequestDuration();
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "EasyChallenge.API v1");
                c.RoutePrefix = "docs";
            });
            return app;
        }
    }
}
