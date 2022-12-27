namespace Exercise.DataModels
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ContactDto> Contacts { get; set; }
    }
}
