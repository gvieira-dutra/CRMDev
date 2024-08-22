namespace CRMDev.Core.Entities
{
    public class ContactNote(Contact contact, string content) : BaseNote(content)
    {
        public int ContactId { get; private set; } = contact.Id;
    }
}
