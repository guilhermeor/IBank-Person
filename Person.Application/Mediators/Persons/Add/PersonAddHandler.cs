using MediatR;
using Person.Domain;
using Person.Domain.Repositories;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Mediators.Person.Add
{
    public class PersonAddHandler : IRequestHandler<PersonAddRequest,Response<object>>
    {
        private readonly IPersonRepository _clientRepository;

        public PersonAddHandler(IPersonRepository clientRepository) => _clientRepository = clientRepository;

        public Task<Response<object>> Handle(PersonAddRequest request, CancellationToken cancellationToken)
        {
            var client = new Domain.Person(request.Name, request.BirthDay);
            _ = _clientRepository.Save(client);
            return Task.FromResult(new Response<object>(HttpStatusCode.NoContent));
        }
    }
}
