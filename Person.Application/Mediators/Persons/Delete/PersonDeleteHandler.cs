using MediatR;
using Person.Domain.Repositories;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Mediators.Person.Delete
{
    public class PersonDeleteHandler : IRequestHandler<PersonDeleteRequest, Response<object>>
    {
        private readonly IPersonRepository _clientRepository;

        public PersonDeleteHandler(IPersonRepository clientRepository) => _clientRepository = clientRepository;

        public async Task<Response<object>> Handle(PersonDeleteRequest request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.Get(request.Id);
            if (client is null)
                return new(HttpStatusCode.NotFound);

            _ = _clientRepository.Delete(client.Id);
            return new(HttpStatusCode.NoContent);
        }
    }
}
