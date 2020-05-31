using AutoMapper;
using ClientInfo.Domain;
using ClientInfo.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace ClientInfo.Application.Mediators.Clients.Add
{
    public class ClientAddHandler : IBaseNotificationHandler<ClientAddRequest>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientAddHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }
        public Task Handle(ClientAddRequest request, CancellationToken cancellationToken)
        {
            var client = _mapper.Map<Client>(request);
            _clientRepository.Save(client);
            return Task.CompletedTask;
        }
    }
}
