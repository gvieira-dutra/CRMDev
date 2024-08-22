using CRMDev.Core.Entities;

namespace CRMDev.Application.ViewModels
{
    public class ContactDetailVM(string name, string email, string phone, string cellPhone, string fieldOrIndustry, string position, string address, string status, List<ContactNote> notes)
    {
        public string Name { get; private set; } = name;
        public string Email { get; private set; } = email;
        public string Phone { get; private set; } = phone;
        public string CellPhone { get; private set; } = cellPhone;
        public string FieldOrIndustry { get; private set; } = fieldOrIndustry;
        public string Position { get; private set; } = position;
        public string Address { get; private set; } = address;
        public string IsActive { get; private set; } = status;
        public List<ContactNote> Notes { get; private set; } = notes;
    }
}
