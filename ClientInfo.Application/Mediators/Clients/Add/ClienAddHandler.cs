using ClientInfo.Domain;
using ClientInfo.Domain.Repositories;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ClientInfo.Application.Mediators.Clients.Add
{
    public class ClientAddHandler : IRequestHandler<ClientAddRequest,Response<object>>
    {
        private readonly IClientRepository _clientRepository;

        public ClientAddHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task<Response<object>> Handle(ClientAddRequest request, CancellationToken cancellationToken)
        {
            var client = new Client(request.Name, request.BirthDay);
            _ = _clientRepository.Save(client);
            return Task.FromResult(new Response<object>(HttpStatusCode.NoContent));
        }
    }
}
