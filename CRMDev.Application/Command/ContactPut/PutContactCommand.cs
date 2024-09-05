using CRMDev.Application.ViewModels;
using CRMDev.Core.Entities;
using MediatR;

namespace CRMDev.Application.Command.ContactPut
{
    public class PutContactCommand : IRequest<ContactDetailVM>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; } 
        //public FieldOrIndustry FieldOrIndustry { get; set; }
        public string Position { get; set; }
        public string Address { get; set; } 
    }
}
