using MediatR;
using Person.Application.Mediators.Persons.Records.Requests;
using Person.Domain.Repositories;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Mediators.Person.Handlers
{
    public class PersonDeleteHandler : IRequestHandler<PersonDeleteRequest, Response<object>>
    {
        private readonly IPersonRepository _personRepository;

        public PersonDeleteHandler(IPersonRepository personRepository) => _personRepository = personRepository;

        public async Task<Response<object>> Handle(PersonDeleteRequest request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.Get(request.Id);
            if (person is null)
                return new(HttpStatusCode.NotFound);

            _ = _personRepository.Delete(person.Id);
            return new(HttpStatusCode.NoContent);
        }
    }
}
