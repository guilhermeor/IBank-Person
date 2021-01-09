using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Person.Application.Settings;
using Person.Domain.Repositories;
using Person.Repository.Queries;
using System;
using System.Threading.Channels;

namespace Person.Bootstrap
{
    public static class PersonConfiguration
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton(typeof(IPersonRepository), typeof(PersonRepository));
            services.Configure<PersonSettings>(config.GetSection("PersonDbSettings"));

            var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("camelCase", conventionPack, t => true);

            var mongoSettings = new MongoClientSettings
            {
               
                Server = new MongoServerAddress(
                    config.GetValue<string>("PersonDbSettings:ConnectionString"), 
                    config.GetValue<int>("PersonDbSettings:Port")),
                ServerSelectionTimeout = new TimeSpan(0, 0, 0, 2)
            };
            services.AddSingleton<IMongoClient>(s => new MongoClient(mongoSettings));

            BsonDefaults.GuidRepresentationMode = GuidRepresentationMode.V3;
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

            return services;
        }
    }
}
