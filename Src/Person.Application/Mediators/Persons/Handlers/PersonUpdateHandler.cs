using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Person.Application.Extensions;
using Person.Application.Mediators.Persons.Records.Requests;
using Person.Application.Settings;
using Person.Domain.Repositories;
using System;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Mediators.Person.Handlers
{
    public class PersonUpdateHandler : IRequestHandler<PersonUpdateRequest, Response<object>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IDistributedCache cache;

        public PersonUpdateHandler(IPersonRepository personRepository, IDistributedCache cache)
        {
            _personRepository = personRepository;
            this.cache = cache;
        }

        public async Task<Response<object>> Handle(PersonUpdateRequest request, CancellationToken cancellationToken)
        {            
            if (await _personRepository.Exists(p => p.Id.Equals(request.Id)))
                return new(HttpStatusCode.NotFound);

            var person = request.ToPerson();

            _ = _personRepository.Update(person);
            _ = cache.SetAsync(CacheKeys.Person(request.Id), JsonSerializer.SerializeToUtf8Bytes(person), DateTime.Now.UntilMidnight(), cancellationToken);
            return new(HttpStatusCode.NoContent);
        }
    }
}
