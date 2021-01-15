using Microsoft.Extensions.Caching.Distributed;
using OpenTracing;
using Person.Application.Extensions;
using Person.Application.Mediators.Persons.Records.Requests;
using Person.Application.Mediators.Persons.Records.Responses;
using Person.Application.Settings;
using Person.Domain.Repositories;
using System;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Mediators.Person.Handlers
{
    public class PersonFullHandler : IBaseHandler<PersonFullRequest, Response<PersonFull>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IDistributedCache cache;
        private readonly ITracer tracer;

        public PersonFullHandler(IPersonRepository personRepository, IDistributedCache cache, ITracer tracer)
        {
            _personRepository = personRepository;
            this.cache = cache;
            this.tracer = tracer;
        }

        public async Task<Response<PersonFull>> Handle(PersonFullRequest request, CancellationToken cancellationToken)
        {
            var responseCache = await cache.GetAsync(CacheKeys.Person(request.Id), cancellationToken);
            if (responseCache is null)
            {
                tracer.ActiveSpan.SetTag("cache", false);
                var person = await _personRepository.Get(request.Id);
                _ = cache.SetAsync(CacheKeys.Person(request.Id), JsonSerializer.SerializeToUtf8Bytes(person), DateTime.Now.UntilMidnight(), cancellationToken);
                return person is null ? new(HttpStatusCode.NotFound) : new(person);
            }
            else
            {
                tracer.ActiveSpan.SetTag("cache", true);
                var person = JsonSerializer.Deserialize<Domain.Person>(new ReadOnlySpan<byte>(responseCache));
                return new Response<PersonFull>(person);
            }
        }
    }
}
