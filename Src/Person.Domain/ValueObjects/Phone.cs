namespace Person.Domain.ValueObjects
{
    public readonly struct Phone
    {
        public string CountryCallingCode { get; init; }
        public string AreaCode { get; init; }
        public string Number { get; init; }
        public bool Principal { get; init; }
        public Phone(string countryCallingCode, string areaCode, string number, bool principal = default) 
            => (CountryCallingCode, AreaCode, Number, Principal) = (countryCallingCode, areaCode, number, principal);
        public string FullPhoneNumber() => $"{CountryCallingCode}{AreaCode}{Number}";
    }
}