using ClientInfo.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ClientInfo.Application.Mediators.Clients.GetAll
{

    public class ClientShortHandler : IBaseHandler<ClientShortRequest, Response<IEnumerable<ClientShort>>>
    {
        private readonly IClientRepository _clientRepository;
        public ClientShortHandler(IClientRepository clientRepository) => _clientRepository = clientRepository;

        public async Task<Response<IEnumerable<ClientShort>>> Handle(ClientShortRequest request, CancellationToken cancellationToken)
        {
            var clients = _clientRepository.GetAll(request.PageNumber, request.PageSize);
            if (clients is null)
                return new (HttpStatusCode.NotFound);
            return new ((await clients).Select(c => (ClientShort)c));
        }
    }
}
