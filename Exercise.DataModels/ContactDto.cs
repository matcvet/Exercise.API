namespace Exercise.DataModels
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public int CountryId { get; set; }

        public CompanyDto Company { get; set; }
        public CountryDto Country { get; set; }
    }
}
