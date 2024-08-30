using CRMDev.Application.ViewModels;
using MediatR;

namespace CRMDev.Application.Command.OpportunitySetStatusClosed
{
    public class SetStatusClosedCommand(int id) : IRequest<OpportunityDetailVM>
    {
        public int Id { get; private set; } = id;
    }
}
