using Person.Application.Mediators.Persons.Records.Requests;
using Person.Application.Mediators.Persons.Records.Responses;
using Person.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Mediators.Person.Handlers
{

    public class PersonShortHandler : IBaseHandler<PersonShortRequest, Response<IEnumerable<PersonShort>>>
    {
        private readonly IPersonRepository _personRepository;
        public PersonShortHandler(IPersonRepository personRepository) => _personRepository = personRepository;

        public async Task<Response<IEnumerable<PersonShort>>> Handle(PersonShortRequest request, CancellationToken cancellationToken)
        {
            var persons = await _personRepository.GetAll(request.PageNumber, request.PageSize);
            return persons is null ? new(HttpStatusCode.NotFound) : new(persons.Select(c => (PersonShort)c));
        }
    }
}