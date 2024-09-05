using CRMDev.Application.ViewModels;
using MediatR;

namespace CRMDev.Application.Command.OpportunityCompleteCurrTask
{
    public class CompleteCurrentTaskCommand(int id) : IRequest<OpportunityDetailVM>
    {
        public int Id { get; private set; } = id;
    }
}
