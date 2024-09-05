namespace CRMDev.Core.DTO
{
    public class ContactDTO(int id, string name, string email, string phone, string cellPhone, string position, string address)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Email { get; set; } = email;
        public string Phone { get; set; } = phone;
        public string CellPhone { get; set; } = cellPhone;
        public string Position { get; set; } = position;
        public string Address { get; set; } = address;
    }
}
