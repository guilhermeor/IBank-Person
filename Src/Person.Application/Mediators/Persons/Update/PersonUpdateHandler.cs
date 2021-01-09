using MediatR;
using Person.Domain.Repositories;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Mediators.Person.Update
{
    public class PersonUpdateHandler : IRequestHandler<PersonUpdateRequest, Response<object>>
    {
        private readonly IPersonRepository _personRepository;

        public PersonUpdateHandler(IPersonRepository personRepository) => _personRepository = personRepository;

        public async Task<Response<object>> Handle(PersonUpdateRequest request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.Get(request.Id);
            if (person is null)
                return new(HttpStatusCode.NotFound);

            _ = _personRepository.Update(request.Parse());
            return new(HttpStatusCode.NoContent);
        }
    }
}
