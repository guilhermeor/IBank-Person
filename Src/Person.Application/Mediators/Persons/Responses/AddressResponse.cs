using Person.Domain;

namespace Person.Application.Mediators.Persons
{
    public class AddressResponse
    {
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Uf { get; set; }

        public AddressResponse(Address address)
        {
            ZipCode = address.ZipCode;
            Street = address.Street;
            Number = address.Number;
            District = address.District;
            City = address.City;
            Uf = address.Uf.ToString();
        }

        public static implicit operator AddressResponse(Address address) => new(address);
    }
}
