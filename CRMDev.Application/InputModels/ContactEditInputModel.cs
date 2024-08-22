using CRMDev.Core.Entities;

namespace CRMDev.Application.InputModels
{
    public class ContactEditInputModel(string name, string email, string phone, string cellPhone, FieldOrIndustry fieldOrIndustry, string position, string address)
    {
        public string Name { get; private set; } = name;
        public string Email { get; private set; } = email;
        public string Phone { get; private set; } = phone;
        public string CellPhone { get; private set; } = cellPhone;
        public FieldOrIndustry FieldOrIndustry { get; private set; } = fieldOrIndustry;
        public string Position { get; private set; } = position;
        public string Address { get; private set; } = address;
    }
}
