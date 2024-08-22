using CRMDev.Application.InputModels;
using CRMDev.Application.Services.Interfaces;
using CRMDev.Application.ViewModels;
using CRMDev.Core.Entities;
using CRMDev.Core.Enums;
using CRMDev.Infrastructure.Persistence;

namespace CRMDev.Application.Services.Implementations
{
    public class OpportunityServices : IOpportunityServices
    {
        private readonly CRMDevDbContext? _dbContext;
        public OpportunityServices(CRMDevDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<OpportunityVM> GetAll(string query)
        {
            var opportunities = _dbContext?.Opportunities
                .Select(o => new OpportunityVM(o.Id, o.Title, o.Description, o.Estimative))
                .ToList();

            return opportunities;
        }

        public OpportunityDetailVM GetOne(int id)
        {
            var opportunity = _dbContext?.Opportunities
                .FirstOrDefault(o => o.Id == id);

            return CreateOpportunityDetailVM(opportunity);

        }

        public OpportunityDetailVM Post(CreateOpportunityInputModel opp)
        {
            var opportunity = new Opportunity(
                opp.Title,
                opp.Description,
                opp.DeliveryEstimate,
                opp.Estimative,
                opp.Scope,
                opp.SupportIncluded,
                opp.ContactId
            );

            _dbContext.Opportunities
                .Add(opportunity);

            return CreateOpportunityDetailVM(opportunity);
        }

        public OpportunityDetailVM Put(int id, EditOpportunityInputModel opportunity)
        {
            var oppToBeEdited = _dbContext.Opportunities
                .FirstOrDefault(o => o.Id == id);

            var opp = new Opportunity(
                opportunity.Title,
                opportunity.Description,
                opportunity.DeliveryEstimate,
                opportunity.Estimative,
                opportunity.Scope,
                opportunity.SupportIncluded
            );

            oppToBeEdited.EditOpportunity(opp);

            return CreateOpportunityDetailVM(oppToBeEdited);

            /*
             {
  "title": "Brand New Opportunity",
  "description": "Test Opportunity",
  "deliveryEstimate": "2025-08-22T02:44:15.925Z",
  "estimative": 99999,
  "scope": "All the work",
  "supportIncluded": true,
  "contactId": 8
}
             */
        }

        public OpportunityDetailVM CompleteCurrentTask(int id)
        {
            var opportunity = _dbContext?.Opportunities
               .FirstOrDefault(o => o.Id == id);

            opportunity.AdvanceTask();

            return CreateOpportunityDetailVM(opportunity);
        }


        public OpportunityDetailVM SetStatusClosed(int id)
        {
            var opportunity = _dbContext?.Opportunities
               .FirstOrDefault(o => o.Id == id);

            opportunity.SetStatusClosed();

            return CreateOpportunityDetailVM(opportunity);
        }

        public OpportunityDetailVM SetStatusLost(int id, ReasonForLostDeal reason)
        {
            var opportunity = _dbContext?.Opportunities
               .FirstOrDefault(o => o.Id == id);

            opportunity.SetStatusLost(reason);

            return CreateOpportunityDetailVM(opportunity);
        }

        private OpportunityDetailVM CreateOpportunityDetailVM(Opportunity opportunity)
        {
            var opportunityVM = new OpportunityDetailVM(
                opportunity.Title,
                opportunity.Description,
                opportunity.DeliveryEstimate,
                opportunity.Estimative,
                opportunity.Scope,
                opportunity.SupportIncluded,
                opportunity.Status,
                opportunity.ReasonForLostDeal,
                opportunity.Stages,
                opportunity.ContactId,
                opportunity.Stages[opportunity.CurrentStageTracker].Name.ToString() ?? "N/A",
                opportunity.Stages[opportunity.CurrentStageTracker].Tasks[opportunity.CurrentTaskTracker].Name.ToString() ?? "N/A",
                 opportunity.Stages[opportunity.CurrentStageTracker].Tasks[opportunity.CurrentTaskTracker].Description.ToString() ?? "N/A"

            );

            return opportunityVM;
        }
    }
}
