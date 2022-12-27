namespace Exercise.DataModels
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ContactDto> Contacts { get; set; }
    }
}
