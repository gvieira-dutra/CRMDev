namespace CRMDev.Application.ViewModels
{
    public class ContactVM(string name, string email, string phone, string fieldOrIndustry, string position)
    {
        public string Name { get; private set; } = name;
        public string Email { get; private set; } = email;
        public string Phone { get; private set; } = phone;
        public string FieldOrIndustry { get; private set; } = fieldOrIndustry;
        public string Position { get; private set; } = position;
    }
}
