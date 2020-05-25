using ClientInfo.API;
using ClientInfo.API.Presenters;
using ClientInfo.Application.Mediators;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Security.Cryptography.X509Certificates;

namespace ClientInfo.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IBasePresenter, BasePresenter>();
            services.AddMediatR(typeof(IBaseHandler<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastPipelineBehavior<,>));
            services.AddScoped(typeof(IRequestExceptionHandler<,,>), typeof(BasePipelineException<,,>));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ibank-client", Version = "v1" });
            });
            var settings = new Settings();
            Configuration.Bind(settings);

            var store = new DocumentStore
            {
                Urls = settings.Database.Urls,
                Database = settings.Database.DatabaseName,
                Certificate = new X509Certificate2($"{Environment.GetEnvironmentVariable("IBankClientCertificate")}/{settings.Database.CertPath}", settings.Database.CertPass)
            };

            store.Initialize();

            services.AddSingleton<IDocumentStore>(store);

            services.AddScoped(serviceProvider =>
            {
                return serviceProvider
                    .GetService<IDocumentStore>()
                    .OpenAsyncSession();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "IStop API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
