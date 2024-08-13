using CRMDev.Core.Enums;

namespace CRMDev.Application.ViewModels
{
    public class OpportunityDetailVM(string title, string description, DateTime deliveryEstimate, decimal estimative, string scope, bool supportIncluded, Status status, ReasonForLostDeal reasonForLostDeal, Stage stage, int contactId)
    {
        public string Title { get; private set; } = title;
        public string Description { get; private set; } = description;
        public DateTime DeliveryEstimate { get; private set; } = deliveryEstimate;
        public decimal Estimative { get; private set; } = estimative;
        public string Scope { get; private set; } = scope;
        public bool SupportIncluded { get; private set; } = supportIncluded;
        public Status Status { get; private set; } = status;
        public ReasonForLostDeal ReasonForLostDeal { get; private set; } = reasonForLostDeal;
        public Stage Stage { get; private set; } = stage;
        public int ContactId { get; private set; } = contactId;
    }
}
