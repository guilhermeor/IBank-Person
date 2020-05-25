namespace ClientInfo.Application.Mediators.Clients
{
    public class AddressResponse
    {
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Uf { get; set; }
    }
}
