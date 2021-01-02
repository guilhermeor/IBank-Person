using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Person.Application.Settings;
using Person.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Person.Repository.Queries
{
    public class PersonRepository : IPersonRepository
    {
        protected readonly IMongoCollection<Domain.Person> _person;
        public PersonRepository(IMongoClient mongoClient, IOptions<PersonSettings> settings)
        {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _person = database.GetCollection<Domain.Person>("persons");
        }

        public async Task Delete(Guid id) => await _person.DeleteOneAsync(c => c.Id.Equals(id));

        public async Task<Domain.Person> Get(Guid id) => (await _person.FindAsync(client => client.Id.Equals(id))).FirstOrDefault();

        public async Task<IEnumerable<Domain.Person>> GetAll(int pageNumber, int pageSize) => (await _person.FindAsync(client => true)).ToEnumerable();

        public Task Save(Domain.Person client) => Task.Run(() => _person.InsertOneAsync(client));

        public async Task Update(Domain.Person client) => await _person.ReplaceOneAsync(c => c.Id.Equals(client.Id), client);
    }
}