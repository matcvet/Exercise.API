namespace Exercise.Services.Models
{
    public class CountryServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ContactServiceModel> Contacts = new List<ContactServiceModel>();
    }
}
