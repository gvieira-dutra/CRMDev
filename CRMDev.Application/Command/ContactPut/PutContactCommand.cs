using CRMDev.Application.ViewModels;
using CRMDev.Core.Entities;
using MediatR;

namespace CRMDev.Application.Command.ContactPut
{
    public class PutContactCommand : IRequest<ContactDetailVM>
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string CellPhone { get; private set; } 
        public FieldOrIndustry FieldOrIndustry { get; private set; }
        public string Position { get; private set; }
        public string Address { get; private set; } 
    }
}
