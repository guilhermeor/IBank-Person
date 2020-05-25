using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ClientInfo.Domain.Repositories;

namespace ClientInfo.Application.Mediators.Clients.GetById
{
    public class ClientFullHandler : IBaseHandler<ClientFullRequest, Response<ClientFull>>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ClientFullHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<Response<ClientFull>> Handle(ClientFullRequest request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.Get(request.Id);
            return new Response<ClientFull>(request.Notifications, _mapper.Map<ClientFull>(client));
        }
    }
}
