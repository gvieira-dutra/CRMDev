using CRMDev.Core.Enums;

namespace CRMDev.Core.Entities
{
    public class Opportunity(string title, string description, DateTime deliveryEstimate, decimal estimative, string scope, bool supportIncluded, Stage stage, int contactId, Contact contact) : BaseClass
    {
        public string Title { get; private set; } = title;
        public string Description { get; private set; } = description;
        public DateTime DeliveryEstimate { get; private set; } = deliveryEstimate;
        public decimal Estimative { get; private set; } = estimative;
        public string Scope { get; private set; } = scope;
        public bool SupportIncluded { get; private set; } = supportIncluded;
        public Status Status { get; private set; } = Status.Open;
        public ReasonForLostDeal ReasonForLostDeal { get; private set; } = ReasonForLostDeal.NA;
        public Stage Stage { get; private set; } = stage;
        public int ContactId { get; private set; } = contactId;
        //public Contact Contact { get; private set; } = contact;
    }

}
