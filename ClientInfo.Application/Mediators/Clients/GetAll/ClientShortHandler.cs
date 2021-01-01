using ClientInfo.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ClientInfo.Application.Mediators.Clients.GetAll
{
    using ObjectResult = Response<IEnumerable<ClientShort>>;

    public class ClientShortHandler : IBaseHandler<ClientShortRequest, ObjectResult>
    {
        private readonly IClientRepository _clientRepository;
        public ClientShortHandler(IClientRepository clientRepository) => _clientRepository = clientRepository;

        public async Task<ObjectResult> Handle(ClientShortRequest request, CancellationToken cancellationToken)
        {
            var clients = _clientRepository.GetAll(request.PageNumber, request.PageSize);
            if (clients is null)
                return new ObjectResult(HttpStatusCode.NotFound);
            return new ObjectResult((await clients).Select(c => (ClientShort)c));
        }
    }
}
