using Person.Domain;
using Person.Domain.Enums;

namespace Person.Application.Mediators.Persons.Records.Requests
{
    public class AddressRequest
    {
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public Uf Uf { get; set; }

        public Address Parse() => new(ZipCode, Street, Number, District, City, Uf);

    }
}
