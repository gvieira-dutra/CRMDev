using CRMDev.Application.ViewModels;
using MediatR;

namespace CRMDev.Application.Command.PostOpportunity
{
    public class PutOpportunityCommand : IRequest<OpportunityDetailVM>
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; } 
        public DateTime DeliveryEstimate { get; set; } 
        public decimal Estimative { get; set; } 
        public string Scope { get; set; } 
        public bool SupportIncluded { get; set; } 
    }
}
