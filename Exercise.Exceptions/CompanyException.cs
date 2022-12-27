namespace Exercise.Exceptions
{
    public class CompanyException : Exception
    {
        public int CompanyId { get; set; }

        public CompanyException() : base("There has been an issue with a company.") { }
        public CompanyException(string message) : base(message) { }
        public CompanyException(int companyId, string message) : base(message)
        {
            CompanyId = companyId;
        }
    }
}
