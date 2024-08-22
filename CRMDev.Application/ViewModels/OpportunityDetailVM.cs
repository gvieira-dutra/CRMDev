using CRMDev.Core.Entities;
using CRMDev.Core.Enums;

namespace CRMDev.Application.ViewModels
{
    public class OpportunityDetailVM(string title, string description, DateTime deliveryEstimate, decimal estimative, string scope, bool supportIncluded, Status status, ReasonForLostDeal reasonForLostDeal, List<Stage> stages, int contactId, string currStage, string currTask, string currTaskDescrip)
    {
        public string Title { get; private set; } = title;
        public string Description { get; private set; } = description;
        public DateTime DeliveryEstimate { get; private set; } = deliveryEstimate;
        public decimal Estimative { get; private set; } = estimative;
        public string Scope { get; private set; } = scope;
        public bool SupportIncluded { get; private set; } = supportIncluded;
        public string Status { get; private set; } = status.ToString();
        public string ReasonForLostDeal { get; private set; } = reasonForLostDeal.ToString();
        public int ContactId { get; private set; } = contactId;
        public string CurrStage { get; private set; } = currStage;
        public string CurrTask { get; private set; } = currTask;
        public string CurrTaskDescrip { get; private set; } = currTaskDescrip;
        public List<Stage> Stages { get; private set; } = stages;
    }
}
