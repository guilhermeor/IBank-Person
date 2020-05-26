using AutoMapper;
using ClientInfo.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ClientInfo.Application.Mediators.Clients.GetAll
{
    public class ClientShortHandler : IBaseHandler<ClientShortRequest, Response<IEnumerable<ClientShort>>>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ClientShortHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<ClientShort>>> Handle(ClientShortRequest request, CancellationToken cancellationToken)
        {
            var clients = await _clientRepository.GetAll(request.PageNumber, request.PageSize);
            return new Response<IEnumerable<ClientShort>>(request.Notifications, _mapper.Map<IEnumerable<ClientShort>>(clients));
        }
    }
}
