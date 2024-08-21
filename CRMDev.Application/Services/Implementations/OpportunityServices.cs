using CRMDev.Application.InputModels;
using CRMDev.Application.Services.Interfaces;
using CRMDev.Application.ViewModels;
using CRMDev.Core.Entities;
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

        public OpportunityDetailVM Post(CreateOpportunityInputModel opportunity)
        {
            throw new NotImplementedException();
        }

        public OpportunityDetailVM Put(EditOpportunityInputModel opportunity)
        {
            throw new NotImplementedException();
        }

        public OpportunityDetailVM CompleteTask(int id)
        {
            var opportunity = _dbContext?.Opportunities
               .FirstOrDefault(o => o.Id == id);

            opportunity.AdvanceTask();

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


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
