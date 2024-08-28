using System.Text.Json.Serialization;

namespace CRMDev.Core.Entities
{
    public class Contact : BaseClass
    {
        public Contact() {}
        public Contact(string name, string email, string phone, string cellPhone, FieldOrIndustry fieldOrIndustry, string position, string address)
        {
            Name = name;
            Email = email;
            Phone = phone;
            CellPhone = cellPhone ?? "N/A";
            FieldOrIndustry = fieldOrIndustry;
            Position = position;
            Address = address;
            IsActive = true;
            Notes = new List<ContactNote>();
            Opportunities = new List<Opportunity>();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string CellPhone { get; private set; }
        [JsonIgnore]
        public FieldOrIndustry FieldOrIndustry { get; private set; }
        public string Position { get; private set; }
        public string Address { get; private set; }
        public bool IsActive { get; private set; }
        public string? ContactNotesSummary { get; private set; }
        [JsonIgnore]
        public List<ContactNote> Notes { get; private set; }
        [JsonIgnore]
        public List<Opportunity> Opportunities { get; private set; }
        public int FieldOrIndustryId { get; private set; }

        public void AddContactNote(ContactNote note)
        {
            Notes.Add(note ?? throw new ArgumentNullException(nameof(note)));
        }

        public void DeleteContact()
        {
            IsActive = false;
        }

        public void EditContact(Contact newContactInfo)
        {
            Name = string.IsNullOrEmpty(newContactInfo.Name) ? Name : newContactInfo.Name;
            Email = string.IsNullOrEmpty(newContactInfo.Email) ? Email : newContactInfo.Email;
            Phone = string.IsNullOrEmpty(newContactInfo.Phone) ? Phone : newContactInfo.Phone;
            CellPhone = string.IsNullOrEmpty(newContactInfo.CellPhone) ? CellPhone : newContactInfo.CellPhone;
            FieldOrIndustry = newContactInfo.FieldOrIndustry ?? FieldOrIndustry;
            Position = string.IsNullOrEmpty(newContactInfo.Position) ? Position : newContactInfo.Position;
            Address = string.IsNullOrEmpty(newContactInfo.Address) ? Address : newContactInfo.Address;

        }

        public void CreateContactNotesSummary()
        {
            //ContactNotesSummary
        }
    }
}
