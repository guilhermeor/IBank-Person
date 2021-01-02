using MediatR;
using Person.Domain.Repositories;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Mediators.Person.Update
{
    public class PersonUpdateHandler : IRequestHandler<PersonUpdateRequest, Response<object>>
    {
        private readonly IPersonRepository _clientRepository;

        public PersonUpdateHandler(IPersonRepository clientRepository) => _clientRepository = clientRepository;

        public async Task<Response<object>> Handle(PersonUpdateRequest request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.Get(request.Id);
            if (client is null)
                return new(HttpStatusCode.NotFound);

            _ = _clientRepository.Update(request.Parse());
            return new(HttpStatusCode.NoContent);
        }
    }
}
