using ClientInfo.Application.Settings;
using ClientInfo.Domain;
using ClientInfo.Domain.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientInfo.Repository.Queries
{
    public class ClientRepository : IClientRepository
    {
        protected readonly IMongoCollection<Client> _clients;
        public ClientRepository(IMongoClient mongoClient, IOptions<ClientSettings> settings)
        {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _clients = database.GetCollection<Client>("clients");
        }

        public Task Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Client> Get(Guid id) => (await _clients.FindAsync(client => client.Id.Equals(id))).FirstOrDefault();

        public async Task<IEnumerable<Client>> GetAll(int pageNumber, int pageSize)
        {
            return (await _clients.FindAsync(client => true))?.ToEnumerable();
        }

        public Task Save(Client client)
        {
            return Task.Run(() => _clients.InsertOneAsync(client));

        }

        public Task Update(Client client)
        {
            throw new System.NotImplementedException();
        }
    }
}