using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Person.Application.Settings;
using Person.Domain.Repositories;
using Person.Repository.Queries;

namespace Person.Bootstrap
{
    public static class PersonConfiguration
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton(typeof(IPersonRepository), typeof(PersonRepository));

            services.Configure<PersonSettings>(config.GetSection("ClientDbSettings"));
            services.AddSingleton<IMongoClient>(s =>
                new MongoClient(config.GetValue<string>("ClientDbSettings:ConnectionString")));

            BsonDefaults.GuidRepresentationMode = GuidRepresentationMode.V3;
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

            return services;
        }
    }
}
