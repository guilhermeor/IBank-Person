using Person.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Person.Application.Mediators.Persons.Records.Responses
{
    public record IdentificationResponse(string Cpf, IEnumerable<DocumentResponse> Documents)
    {
        public static implicit operator IdentificationResponse(Identification identification) 
            => new(identification.CpfNumber, identification.Documents.Select(i => (DocumentResponse)i));
    }
}