using Person.Domain;

namespace Person.Application.Mediators.Persons.Records.Responses
{
    public record AddressResponse(string ZipCode, string Street, int Number, string District, string City, string Uf)
    {
        public static implicit operator AddressResponse(Address address)
            => new
            (
                address.ZipCode,
                address.Street,
                address.Number,
                address.District,
                address.City,
                address.Uf.ToString()
                );
    }
}
