using CRMDev.Application.ViewModels;
using MediatR;

namespace CRMDev.Application.Command.OpportunityCompleteCurrTask
{
    public class CompleteCurrentTaskCommand : IRequest<OpportunityDetailVM>
    {
        public int Id { get; private set; }
    }
}
