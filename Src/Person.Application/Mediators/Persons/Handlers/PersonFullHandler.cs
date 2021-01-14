using Person.Application.Mediators.Persons.Records.Requests;
using Person.Application.Mediators.Persons.Records.Responses;
using Person.Domain.Repositories;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Mediators.Person.Handlers
{
    public class PersonFullHandler : IBaseHandler<PersonFullRequest, Response<PersonFull>>
    {
        private readonly IPersonRepository _personRepository;
        public PersonFullHandler(IPersonRepository personRepository) => _personRepository = personRepository;

        public async Task<Response<PersonFull>> Handle(PersonFullRequest request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.Get(request.Id);
            return person is null ? new(HttpStatusCode.NotFound) : new(person);
        }
    }
}
