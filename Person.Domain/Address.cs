using Person.Domain.Enums;

namespace Person.Domain
{
    public class Address
    {
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public Uf Uf { get; set; }

        public Address(string zipCode, string street, int number, string district, string city, Uf uf)
        {
            ZipCode = zipCode;
            Street = street;
            Number = number;
            District = district;
            City = city;
            Uf = uf;
        }
    }
}
