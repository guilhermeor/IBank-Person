using Person.Domain.Repositories;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Mediators.Clients.Update
{
    public class ClientUpdateHandler : IRequestHandler<ClientUpdateRequest, Response<object>>
    {
        private readonly IClientRepository _clientRepository;

        public ClientUpdateHandler(IClientRepository clientRepository) => _clientRepository = clientRepository;

        public async Task<Response<object>> Handle(ClientUpdateRequest request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.Get(request.Id);
            if (client is null)
                return new(HttpStatusCode.NotFound);

            _ = _clientRepository.Update(request.Parse());
            return new(HttpStatusCode.NoContent);
        }
    }
}
