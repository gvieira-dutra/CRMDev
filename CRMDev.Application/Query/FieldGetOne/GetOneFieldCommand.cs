using CRMDev.Application.ViewModels;
using MediatR;

namespace CRMDev.Application.Query.FieldGetOne
{
    public class GetOneFieldCommand : IRequest<FieldOrIndustryVM>
    {
        public int Id { get; set; }
    }
}
