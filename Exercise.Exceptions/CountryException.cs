namespace Exercise.Exceptions
{
    public class CountryException : Exception
    {
        public int CountryId { get; set; }

        public CountryException() : base("There has been an issue with a country") { }
        public CountryException(string message) : base(message) { }
        public CountryException(int countryId, string message) : base(message)
        {
            CountryId = countryId;
        }
    }
}
