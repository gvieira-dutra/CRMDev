﻿namespace CRMDev.Application.InputModels
{
    public class EditOpportunityInputModel(string title, string description, DateTime deliveryEstimate, decimal estimative, string scope, bool supportIncluded)
    {
        public string Title { get; private set; } = title;
        public string Description { get; private set; } = description;
        public DateTime DeliveryEstimate { get; private set; } = deliveryEstimate;
        public decimal Estimative { get; private set; } = estimative;
        public string Scope { get; private set; } = scope;
        public bool SupportIncluded { get; private set; } = supportIncluded;
    }
}
