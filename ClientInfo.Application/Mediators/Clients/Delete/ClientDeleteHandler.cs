using ClientInfo.Domain.Repositories;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ClientInfo.Application.Mediators.Clients.Delete
{
    using ObjectResult = Response<object>;
    public class ClientDeleteHandler : IRequestHandler<ClientDeleteRequest, ObjectResult>
    {
        private readonly IClientRepository _clientRepository;

        public ClientDeleteHandler(IClientRepository clientRepository) => _clientRepository = clientRepository;

        public async Task<ObjectResult> Handle(ClientDeleteRequest request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.Get(request.Id);
            if (client is null)
                return new(HttpStatusCode.NotFound);

            _ = _clientRepository.Delete(client.Id);
            return new(HttpStatusCode.NoContent);
        }
    }
}
