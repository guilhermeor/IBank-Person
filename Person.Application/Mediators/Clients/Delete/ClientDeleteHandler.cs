using Person.Domain.Repositories;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Mediators.Clients.Delete
{
    public class ClientDeleteHandler : IRequestHandler<ClientDeleteRequest, Response<object>>
    {
        private readonly IClientRepository _clientRepository;

        public ClientDeleteHandler(IClientRepository clientRepository) => _clientRepository = clientRepository;

        public async Task<Response<object>> Handle(ClientDeleteRequest request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.Get(request.Id);
            if (client is null)
                return new(HttpStatusCode.NotFound);

            _ = _clientRepository.Delete(client.Id);
            return new(HttpStatusCode.NoContent);
        }
    }
}
