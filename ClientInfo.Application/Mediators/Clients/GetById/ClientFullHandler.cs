using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ClientInfo.Domain.Repositories;

namespace ClientInfo.Application.Mediators.Clients.GetById
{
    public class ClientFullHandler : IBaseHandler<ClientFullRequest, Response<ClientFull>>
    {
        private readonly IClientRepository _clientRepository;
        public ClientFullHandler(IClientRepository clientRepository) => _clientRepository = clientRepository;

        public async Task<Response<ClientFull>> Handle(ClientFullRequest request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.Get(request.Id);
            return client is null ? new(HttpStatusCode.NotFound) : new(client);
        }
    }
}
