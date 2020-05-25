using ClientInfo.Domain;
using ClientInfo.Domain.Repositories;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientInfo.Repository.Queries
{
    public class ClientQuery : IClientRepository
    {
        private readonly IAsyncDocumentSession _session;
        public ClientQuery(IAsyncDocumentSession session) => _session = session;
        public async Task<Client> Get(string id) => await _session.LoadAsync<Client>(id);

        public async Task<IEnumerable<Client>> GetAll() => await _session.Query<Client>().ToListAsync();
    }
}
