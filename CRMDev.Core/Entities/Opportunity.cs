using CRMDev.Core.Enums;

namespace CRMDev.Core.Entities
{
    public class Opportunity: BaseClass
    {
        public Opportunity() {}
        public Opportunity(string title, string description, DateTime deliveryEstimate, decimal estimative, string scope, bool supportIncluded, int contactId)
        {
            Title = title;
            Description = description;
            DeliveryEstimate = deliveryEstimate;
            Estimative = estimative;
            Scope = scope;
            SupportIncluded = supportIncluded;
            Status = Status.Open;
            ReasonForLostDeal = ReasonForLostDeal.NA;
            ContactId = contactId;
            Stages = CreateDefaultStages();
            CurrentStageTracker = 0;
            CurrentTaskTracker = 0;
        }

        public Opportunity(string title, string description, DateTime deliveryEstimate, decimal estimative, string scope, bool supportIncluded )
        {
            Title = title;
            Description = description;
            DeliveryEstimate = deliveryEstimate;
            Estimative = estimative;
            Scope = scope;
            SupportIncluded = supportIncluded;
        }

        public string Title { get; private set; }
        public string Description { get; private set; } 
        public DateTime DeliveryEstimate { get; private set; } 
        public decimal Estimative { get; private set; }
        public string Scope { get; private set; } 
        public bool SupportIncluded { get; private set; } 
        public Status Status { get; private set; } 
        public ReasonForLostDeal ReasonForLostDeal { get; private set; }
        public int ContactId { get; private set; }
        public int CurrentStageTracker { get; private set; }
        public int CurrentTaskTracker { get; private set; }
        public List<Stage> Stages { get; private set; }

        static private List<Stage> CreateDefaultStages()
        {
                return new List<Stage>
                {
                new Stage("Contacted", new List<Task>
                {
                    new Task("Initial Follow-Up Email", "Send a follow-up email to confirm the receipt of the initial contact and schedule a next step."),
                    new Task("Research Prospect", "Gather more information about the prospect's company and needs."),
                    new Task("Record Contact Information", "Ensure all contact details are accurately recorded in the CRM.")
                }),
                new Stage("PreQualified", new List<Task>
                {
                    new Task("Qualification Call", "Schedule and conduct a call to assess the prospect's needs, budget, and timeline."),
                    new Task("Identify Decision Makers", "Determine who in the organization is responsible for making purchasing decisions."),
                    new Task("Assess Budget", "Confirm the prospect's budget aligns with the solution being offered.")
                }),
                new Stage("Connected", new List<Task>
                {
                    new Task("Send Product Information", "Provide detailed information or brochures about your product or service."),
                    new Task("Discuss Pain Points", "Have a discussion to understand the specific challenges the prospect is facing."),
                    new Task("Schedule Demo", "Arrange a product demo or service walkthrough if applicable.")
                }),
                new Stage("MeetingScheduled", new List<Task>
                {
                    new Task("Prepare Meeting Agenda", "Outline key discussion points and objectives for the upcoming meeting."),
                    new Task("Send Meeting Confirmation", "Send a confirmation email or message with the meeting details and agenda."),
                    new Task("Internal Prep Meeting", "Conduct a meeting with internal team members to align on goals and strategy for the upcoming client meeting.")
                }),
                new Stage("SentProposition", new List<Task>
                {
                    new Task("Draft Proposal", "Prepare a tailored proposal or quote based on the prospect's requirements."),
                    new Task("Review Proposal with Team", "Have an internal review of the proposal to ensure accuracy and alignment with the client’s needs."),
                    new Task("Follow-Up on Proposal", "Send a follow-up email or call to discuss the proposal and address any questions.")
                }),
                new Stage("WaitingSignature", new List<Task>
                {
                    new Task("Send Contract", "Send the official contract or agreement to the prospect for signature."),
                    new Task("Follow-Up on Contract", "Follow up with the prospect to ensure they have received the contract and address any concerns."),
                    new Task("Prepare Onboarding Plan", "Start preparing an onboarding plan in anticipation of a signed contract.")
                }),
                new Stage("Closed", new List<Task>
                {
                    new Task("Send Thank You Email", "Send a thank-you email and confirm the start of the service or product delivery."),
                    new Task("Onboarding/Implementation Kickoff", "Begin the onboarding or implementation process for the client."),
                    new Task("Request Referral", "Ask the client for referrals or testimonials if appropriate.")
                })
                };
               }

        public void AdvanceTask()
        {
            Stages[CurrentStageTracker]
                .Tasks[CurrentTaskTracker]
                .MarkAsCompleted();

            if(CurrentTaskTracker == Stages[CurrentStageTracker].Tasks.Count())
            {
                CurrentStageTracker += 1;
                CurrentTaskTracker = 0;
            }
            else
            {
                CurrentTaskTracker += 1;
            }
        }

        public void SetStatusClosed()
        {
            Status = Status.Closed;
        }

        public void SetStatusLost(ReasonForLostDeal reason)
        {
            Status = Status.Lost;
            ReasonForLostDeal = reason;
        }

        public void EditOpportunity(Opportunity oppNewInfo)
        {
            Title = string.IsNullOrEmpty(oppNewInfo.Title) ? Title : oppNewInfo.Title;
           
            Description = string.IsNullOrEmpty(oppNewInfo.Description) ? Description : oppNewInfo.Description;
            
            DeliveryEstimate = oppNewInfo.DeliveryEstimate == default ? DeliveryEstimate : oppNewInfo.DeliveryEstimate;
            
            Estimative = oppNewInfo.Estimative == default ? Estimative : oppNewInfo.Estimative;
            
            Scope = string.IsNullOrEmpty(oppNewInfo.Scope) ? Scope : oppNewInfo.Scope;
            
            SupportIncluded = oppNewInfo.SupportIncluded ? SupportIncluded : oppNewInfo.SupportIncluded ;

        }
    }

}
