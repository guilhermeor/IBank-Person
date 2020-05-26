using ClientInfo.Domain.Enums;

namespace ClientInfo.Domain
{
    public class Address
    {
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public Uf Uf { get; set; }
    }
}
