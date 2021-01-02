using MediatR;
using Person.Domain.Repositories;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Mediators.Person.Add
{
    public class PersonAddHandler : IRequestHandler<PersonAddRequest,Response<object>>
    {
        private readonly IPersonRepository _personRepository;

        public PersonAddHandler(IPersonRepository personRepository) => _personRepository = personRepository;

        public Task<Response<object>> Handle(PersonAddRequest request, CancellationToken cancellationToken)
        {
            _ = _personRepository.Save(request.Parse());
            return Task.FromResult(new Response<object>(HttpStatusCode.NoContent));
        }
    }
}
