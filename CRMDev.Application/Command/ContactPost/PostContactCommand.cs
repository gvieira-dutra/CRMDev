using CRMDev.Application.ViewModels;
using MediatR;

namespace CRMDev.Application.Command.ContactPost
{
    public
        class PostContactCommand : IRequest<ContactDetailVM>
    {
        public string Name { get; set; } 
        public string Email { get; set; }
        public string Phone { get; set; } 
        public string CellPhone { get; set; }
        public int FieldOrIndustryId { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
    }
}
