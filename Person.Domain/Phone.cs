namespace Person.Domain
{
    public class Phone
    {
        public string CountryCallingCode { get; set; }
        public string AreaCode { get; set; }
        public string Number { get; set; }

        public Phone(string countryCode, string areaCode, string number) => (CountryCallingCode, AreaCode, Number) = (countryCode, areaCode, number);

        public string FullPhoneNumber() => $"{CountryCallingCode}{AreaCode}{Number}";
    }
}