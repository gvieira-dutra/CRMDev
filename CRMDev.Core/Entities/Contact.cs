namespace CRMDev.Core.Entities
{
    public class Contact(string name, string email, string phone, string cellPhone, FieldOrIndustry fieldOrIndustry, string position, string address) : BaseClass
    {
        public string Name { get; private set; } = name;
        public string Email { get; private set; } = email;
        public string Phone { get; private set; } = phone;
        public string CellPhone { get; private set; } = cellPhone;
        public FieldOrIndustry FieldOrIndustry { get; private set; } = fieldOrIndustry;
        public string Position { get; private set; } = position;
        public string Address { get; private set; } = address;
        public List<Note> Notes { get; private set; }

        public void AddNote(Note note)
        {
            Notes.Add(note ?? throw new ArgumentNullException(nameof(note)));
        }
    }
}
