using CRMDev.Application.ViewModels;
using MediatR;

namespace CRMDev.Application.Query.OpportunityGetOne
{
    public class GetOneOpportunityCommand(int id) : IRequest<OpportunityDetailVM>
    {
        public int Id { get; private set; } = id;
    }
}
