using Person.Domain.Repositories;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Mediators.Person.GetById
{
    public class PersonFullHandler : IBaseHandler<PersonFullRequest, Response<PersonFull>>
    {
        private readonly IPersonRepository _clientRepository;
        public PersonFullHandler(IPersonRepository clientRepository) => _clientRepository = clientRepository;

        public async Task<Response<PersonFull>> Handle(PersonFullRequest request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.Get(request.Id);
            return client is null ? new(HttpStatusCode.NotFound) : new(client);
        }
    }
}
