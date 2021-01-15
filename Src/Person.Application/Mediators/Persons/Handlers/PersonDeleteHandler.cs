using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Person.Application.Mediators.Persons.Records.Requests;
using Person.Application.Settings;
using Person.Domain.Repositories;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Mediators.Person.Handlers
{
    public class PersonDeleteHandler : IRequestHandler<PersonDeleteRequest, Response<object>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IDistributedCache cache;

        public PersonDeleteHandler(IPersonRepository personRepository, IDistributedCache cache)
        {
            _personRepository = personRepository;
            this.cache = cache;
        }

        public async Task<Response<object>> Handle(PersonDeleteRequest request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.Get(request.Id);
            if (person is null)
                return new(HttpStatusCode.NotFound);

            _ = _personRepository.Delete(person.Id);
            _ = cache.RemoveAsync(CacheKeys.Person(request.Id), cancellationToken);

            return new(HttpStatusCode.NoContent);
        }
    }
}
