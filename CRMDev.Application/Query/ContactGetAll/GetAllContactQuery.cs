using CRMDev.Application.ViewModels;
using MediatR;

namespace CRMDev.Application.Query.ContactGetAll
{
    public class GetAllContactQuery : IRequest<List<ContactVM>>
    {
        public string Query { get; set; }
    }
}
