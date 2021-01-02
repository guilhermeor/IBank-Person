using Person.API.Presenters;
using Person.Application.Mediators;
using Person.Application.Mediators.Clients.Add;
using Person.Application.Mediators.Clients.GetById;
using Person.Application.Settings;
using Person.Domain.Repositories;
using Person.Repository.Queries;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System.Globalization;

namespace Person.API
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
            services.AddSingleton(typeof(IClientRepository), typeof(ClientRepository));
            services.AddControllers();
            services.AddTransient<IBasePresenter, BasePresenter>();

            services.AddMediatR(typeof(IBaseHandler<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastPipelineBehavior<,>));
            services.AddScoped(typeof(IRequestExceptionHandler<,>), typeof(BasePipelineException<,>));       

            services.AddMemoryCache();


            services.AddMvc().AddJsonOptions(options => { options.JsonSerializerOptions.IgnoreNullValues = true; }).AddFluentValidation();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ibank-client", Version = "v1" });
            });
            services.Configure<ClientSettings>(Configuration.GetSection("ClientDbSettings"));
            services.AddSingleton<IMongoClient>(s =>
            new MongoClient(Configuration.GetValue<string>("ClientDbSettings:ConnectionString")));

            ValidatorOptions.Global.LanguageManager = new FluentValidation.Resources.LanguageManager() {Culture = CultureInfo.GetCultureInfo("en-US") };
            services.AddTransient<IValidator<ClientAddRequest>, ClientAddValidator>();
            services.AddTransient<IValidator<ClientFullRequest>, ClientFullValidator>();
            services.AddTransient<IValidator<ClientFullRequest>, ClientFullValidator>();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            BsonDefaults.GuidRepresentationMode = GuidRepresentationMode.V3;
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "IBank Client API V1");
                c.RoutePrefix = string.Empty;
                c.DisplayRequestDuration();
            });
        }
    }
}
