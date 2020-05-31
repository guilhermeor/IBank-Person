using ClientInfo.Domain;
using ClientInfo.Domain.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientInfo.Repository.Queries
{
    public class ClientRepository : IClientRepository
    {
        private readonly IAsyncDocumentSession _session;
        private readonly IMemoryCache _cache;
        public ClientRepository(IAsyncDocumentSession session, IMemoryCache cache)
        {
            _session = session;
            _cache = cache;
        }

        public void Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Client> Get(string id) => await _cache.GetOrCreateAsync($"client/{id}", _ => _session.LoadAsync<Client>(id));

        public async Task<IEnumerable<Client>> GetAll(int pageNumber, int pageSize)
        {
            return await _cache.GetOrCreateAsync("clients",
                _ => _session.Query<Client>(collectionName: "Client")
                    .Skip(pageNumber * pageSize).Take(pageSize).ToListAsync());
        }

        public void Save(Client client)
        {
            _session.StoreAsync(client);
            _session.SaveChangesAsync();
        }

        public void Update(Client client)
        {
            throw new System.NotImplementedException();
        }
    }
}