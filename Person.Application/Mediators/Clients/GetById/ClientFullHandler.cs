using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Person.Domain.Repositories;

namespace Person.Application.Mediators.Clients.GetById
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
