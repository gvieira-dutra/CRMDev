using CRMDev.Application.InputModels;
using CRMDev.Application.Services.Interfaces;
using CRMDev.Application.ViewModels;
using CRMDev.Core.Entities;
using CRMDev.Core.Enums;
using CRMDev.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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
                .Include(s => s.Stages)
                    .ThenInclude(t => t.Tasks)
                .Include(c => c.Contact)
                .SingleOrDefault(o => o.Id == id);

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

            _dbContext.SaveChanges();

            return CreateOpportunityDetailVM(opportunity);
        }

        public OpportunityDetailVM Put(int id, EditOpportunityInputModel opportunity)
        {
            var oppToBeEdited = _dbContext?.Opportunities
               .Include(s => s.Stages)
                   .ThenInclude(t => t.Tasks)
               .Include(c => c.Contact)
               .SingleOrDefault(o => o.Id == id);

            var opp = new Opportunity(
                opportunity.Title,
                opportunity.Description,
                opportunity.DeliveryEstimate,
                opportunity.Estimative,
                opportunity.Scope,
                opportunity.SupportIncluded
            );

            oppToBeEdited.EditOpportunity(opp);

            _dbContext.SaveChanges();

            return CreateOpportunityDetailVM(oppToBeEdited);
        }

        public OpportunityDetailVM CompleteCurrentTask(int id)
        {
            var opportunity = _dbContext?.Opportunities
               .Include(s => s.Stages)
                   .ThenInclude(t => t.Tasks)
               .Include(c => c.Contact)
               .SingleOrDefault(o => o.Id == id);

            opportunity.AdvanceTask();

            _dbContext.SaveChanges();

            return CreateOpportunityDetailVM(opportunity);
        }


        public OpportunityDetailVM SetStatusClosed(int id)
        {
            var opportunity = _dbContext?.Opportunities
               .Include(s => s.Stages)
                   .ThenInclude(t => t.Tasks)
               .Include(c => c.Contact)
               .SingleOrDefault(o => o.Id == id);

            opportunity.SetStatusClosed();

            _dbContext.SaveChanges();

            return CreateOpportunityDetailVM(opportunity);
        }

        public OpportunityDetailVM SetStatusLost(int id, ReasonForLostDeal reason)
        {
            var opportunity = _dbContext?.Opportunities
               .Include(s => s.Stages)
                   .ThenInclude(t => t.Tasks)
               .Include(c => c.Contact)
               .SingleOrDefault(o => o.Id == id);

            opportunity.SetStatusLost(reason);

            _dbContext.SaveChanges();

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
