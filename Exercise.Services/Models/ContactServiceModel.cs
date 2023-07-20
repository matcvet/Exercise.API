namespace Exercise.Services.Models
{
    public class ContactServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public KeyValuePair<int, string> Company = new KeyValuePair<int, string>();
        public KeyValuePair<int, string> Country = new KeyValuePair<int, string>();
    }
}
