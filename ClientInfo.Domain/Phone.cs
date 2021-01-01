namespace ClientInfo.Domain
{
    public class Phone
    {
        public string CountryCallingCode { get; set; }
        public string AreaCode { get; set; }
        public string Number { get; set; }

        public string FullPhoneNumber() => $"{CountryCallingCode}{AreaCode}{Number}";
    }
}