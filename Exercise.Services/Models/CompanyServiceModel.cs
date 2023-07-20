namespace Exercise.Services.Models
{
    public class CompanyServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ContactServiceModel> Contacts = new List<ContactServiceModel>();
    }
}
