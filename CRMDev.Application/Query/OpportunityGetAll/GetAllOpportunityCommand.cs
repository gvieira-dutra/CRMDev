using CRMDev.Application.ViewModels;
using MediatR;

namespace CRMDev.Application.Query.OpportunityGetAll
{
    public class GetAllOpportunityCommand : IRequest<List<OpportunityVM>>
    {
        public string Query { get; set; } 
    }
}
