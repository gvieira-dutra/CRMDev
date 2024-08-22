using System.Net;
using System.Numerics;
using System.Xml.Linq;

namespace CRMDev.Core.Entities
{
    public class Contact : BaseClass
    {
        public Contact(string name, string email, string phone, string cellPhone, FieldOrIndustry fieldOrIndustry, string position, string address, Note note)
        {
            Name = name;
            Email = email;
            Phone = phone;
            CellPhone = cellPhone ?? "N/A";
            FieldOrIndustry = fieldOrIndustry;
            Position = position;
            Address = address;
            IsActive = true;
            Notes = new List<Note>();
            this.AddContactNote(note);
        }

        public Contact(string name, string email, string phone, string cellPhone, FieldOrIndustry fieldOrIndustry, string position, string address)
        {
            Name = name;
            Email = email;
            Phone = phone;
            CellPhone = cellPhone ?? "N/A";
            FieldOrIndustry = fieldOrIndustry;
            Position = position;
            Address = address;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string CellPhone { get; private set; }
        public FieldOrIndustry FieldOrIndustry { get; private set; }
        public string Position { get; private set; }
        public string Address { get; private set; }
        public bool IsActive { get; private set; }
        public List<Note> Notes { get; private set; }


        public void AddContactNote(Note note)
        {
            Notes.Add(note ?? throw new ArgumentNullException(nameof(note)));
        }

        public void DeleteContact()
        {
            IsActive = false;
        }

        public void EditContact(Contact newContactInfo)
        {
            Name = newContactInfo.Name ?? Name;
            Email = newContactInfo.Email ?? Email;
            Phone = newContactInfo.Phone ?? Phone;
            CellPhone = newContactInfo.CellPhone ?? CellPhone;
            FieldOrIndustry = newContactInfo.FieldOrIndustry ?? FieldOrIndustry;
            Position = newContactInfo.Position ?? Position;
            Address = newContactInfo.Address ?? Address;
        }
    }
}
