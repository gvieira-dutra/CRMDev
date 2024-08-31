using CRMDev.Application.ViewModels;
using MediatR;

namespace CRMDev.Application.Command.ContactPost
{
    public
        class PostContactCommand : IRequest<ContactDetailVM>
    {
        public string Name { get; private set; } 
        public string Email { get; private set; }
        public string Phone { get; private set; } 
        public string CellPhone { get; private set; }
        public int FieldOrIndustryId { get; private set; }
        public string Position { get; private set; }
        public string Address { get; private set; }
    }
}
