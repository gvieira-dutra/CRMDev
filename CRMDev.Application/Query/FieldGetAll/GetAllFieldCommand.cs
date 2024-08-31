using CRMDev.Application.ViewModels;
using MediatR;

namespace CRMDev.Application.Query.FieldGetAll
{
    public class GetAllFieldCommand : IRequest<List<FieldOrIndustryVM>>
    {
    }
}
