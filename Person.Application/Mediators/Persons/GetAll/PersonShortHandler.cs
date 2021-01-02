using Person.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Mediators.Person.GetAll
{

    public class PersonShortHandler : IBaseHandler<PersonShortRequest, Response<IEnumerable<PersonShort>>>
    {
        private readonly IPersonRepository _clientRepository;
        public PersonShortHandler(IPersonRepository clientRepository) => _clientRepository = clientRepository;

        public async Task<Response<IEnumerable<PersonShort>>> Handle(PersonShortRequest request, CancellationToken cancellationToken)
        {
            var clients = _clientRepository.GetAll(request.PageNumber, request.PageSize);
            if (clients is null)
                return new (HttpStatusCode.NotFound);
            return new ((await clients).Select(c => (PersonShort)c));
        }
    }
}
