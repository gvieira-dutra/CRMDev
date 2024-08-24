using System.Text.Json.Serialization;

namespace CRMDev.Core.Entities
{
    public class ContactNote : BaseNote
    {
        public ContactNote(Contact contact, string content) : base(content)
        {
            ContactId = contact.Id;
            Contact = contact;
        }
        public ContactNote() : base() {}
        public int ContactId { get; private set; }

        [JsonIgnore]
        public Contact Contact { get; private set; }
    }
}
