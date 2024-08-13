namespace CRMDev.Application.ViewModels
{
    public class ContactDetailVM(string name, string email, string phone, string cellPhone, string fieldOrIndustry, string position, string address, string notes)
    {
        public string Name { get; private set; } = name;
        public string Email { get; private set; } = email;
        public string Phone { get; private set; } = phone;
        public string CellPhone { get; private set; } = cellPhone;
        public string FieldOrIndustry { get; private set; } = fieldOrIndustry;
        public string Position { get; private set; } = position;
        public string Address { get; private set; } = address;
        public string Notes { get; private set; } = notes;
    }
}
