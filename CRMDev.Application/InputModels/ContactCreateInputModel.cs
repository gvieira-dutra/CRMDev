using CRMDev.Core.Entities;

namespace CRMDev.Application.InputModels
{
    public class ContactCreateInputModel(string name, string email, string phone, string cellPhone, int fieldOrIndustryId, string position, string address)
    {
        public string Name { get; private set; } = name;
        public string Email { get; private set; } = email;
        public string Phone { get; private set; } = phone;
        public string CellPhone { get; private set; } = cellPhone;
        public int FieldOrIndustryId { get; private set; } = fieldOrIndustryId;
        public string Position { get; private set; } = position;
        public string Address { get; private set; } = address;
    }
}
