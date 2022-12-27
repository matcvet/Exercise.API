namespace Exercise.Exceptions
{
    public class ContactException : Exception
    {
        public int? ContactId { get; set; }

        public ContactException() : base("There has been an issue with a contact.") {}

        public ContactException(string message) : base(message) { } 

        public ContactException(int? contactId, string message) : base(message)
        {
            ContactId = contactId;
        }
    }
}
