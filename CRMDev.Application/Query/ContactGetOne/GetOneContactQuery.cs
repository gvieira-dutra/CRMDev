using CRMDev.Application.ViewModels;
using MediatR;

namespace CRMDev.Application.Query.ContactGetOne
{
    public class GetOneContactQuery : IRequest<ContactDetailVM>
    {
        public int Id { get; set; }
    }
}
