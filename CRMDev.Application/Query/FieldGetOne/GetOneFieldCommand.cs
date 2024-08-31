using CRMDev.Application.ViewModels;
using MediatR;

namespace CRMDev.Application.Query.FieldGetOne
{
    public class GetOneFieldCommand(int id) : IRequest<FieldOrIndustryVM>
    {
        public int Id { get; set; } = id;
    }
}
