namespace Person.Domain.ValueObjects
{
    public readonly struct Name
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public Name(string first, string last) => (FirstName, LastName) = (first, last);
    }
}