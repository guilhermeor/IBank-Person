using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Person.Application.Settings;
using Person.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public async Task<Domain.Person> Get(Guid id) => (await _person.FindAsync(person => person.Id.Equals(id))).FirstOrDefault();

        public async Task<IEnumerable<Domain.Person>> GetAll(int pageNumber, int pageSize) => await (await _person.FindAsync(person => true)).ToListAsync();

        public async Task<bool> Exists(Expression<Func<Domain.Person, bool>> filterExpression) => await _person.CountDocumentsAsync(filterExpression) > 0;

        public Task Save(Domain.Person person) => Task.Run(() => _person.InsertOneAsync(person));

        public async Task Update(Domain.Person person) => await _person.ReplaceOneAsync(c => c.Id.Equals(person.Id), person);
    }
}