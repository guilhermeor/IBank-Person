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
    public class ClientQuery : IClientRepository
    {
        private readonly IAsyncDocumentSession _session;
        private readonly IMemoryCache _cache;
        public ClientQuery(IAsyncDocumentSession session, IMemoryCache cache)
        {
            _session = session;
            _cache = cache;
        }

        public async Task<Client> Get(string id) => await _cache.GetOrCreateAsync($"client/{id}", _ => _session.LoadAsync<Client>(id));

        public async Task<IEnumerable<Client>> GetAll(int pageNumber, int pageSize)
        {
            return await _cache.GetOrCreateAsync("clients",
                _ => _session.Query<Client>(collectionName: "Client")
                    .Skip(pageNumber * pageSize).Take(pageSize).ToListAsync());
        }
    }
}