using Person.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Person.Application.Mediators.Persons.Records.Requests
{
    public record IdentificationRequest(string Cpf, IEnumerable<DocumentRequest> Documents)
    {
        public Identification Parse() => new(Cpf, Documents?.Select(d => d.Parse()));
    }
}
