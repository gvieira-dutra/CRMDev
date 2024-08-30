using CRMDev.Application.ViewModels;
using CRMDev.Core.Enums;
using MediatR;

namespace CRMDev.Application.Command.OpportunitySetStatusLost
{
    public class SetStatusLostCommand : IRequest<OpportunityDetailVM>
    {
        public int Id { get; set; }
        public ReasonForLostDeal Reason { get; set; }
    }
}
