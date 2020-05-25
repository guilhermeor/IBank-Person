using Raven.Client.Documents.Session;
using System.Threading;
using System.Threading.Tasks;
using ClientInfo.Domain;

namespace ClientInfo.Application.Mediators.Clients.GetById
{
    public class ClientFullHandler : IBaseHandler<ClientFullRequest, Response<ClientFull>>
    {
        private readonly IAsyncDocumentSession _session;
        public ClientFullHandler(IAsyncDocumentSession session) => _session = session;
        public async Task<Response<ClientFull>> Handle(ClientFullRequest request, CancellationToken cancellationToken)
        {
            var client = await _session.LoadAsync<Client>(request.Id);
            return new Response<ClientFull>(request.Notifications, (ClientFull)client);
        }
    }
}
