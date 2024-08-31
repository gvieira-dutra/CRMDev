using CRMDev.Application.ViewModels;
using MediatR;

namespace CRMDev.Application.Query.ContactGetOne
{
    internal class GetOneContactQuery : IRequest<ContactDetailVM>
    {
        public int Id { get; set; }
    }
}
