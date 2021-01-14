using Person.Application.Mediators.Persons.Records.Requests;
using Person.Domain.Repositories;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Mediators.Person.Handlers
{
    public class PersonAddHandler : IBaseHandler<PersonAddRequest, Response<object>>
    {
        private readonly IPersonRepository _personRepository;

        public PersonAddHandler(IPersonRepository personRepository) => _personRepository = personRepository;

        public Task<Response<object>> Handle(PersonAddRequest request, CancellationToken cancellationToken)
        {
            _ = _personRepository.Save(request.ToPerson());
            return Task.FromResult(new Response<object>(HttpStatusCode.NoContent));
        }
    }
}
