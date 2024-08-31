using CRMDev.Application.ViewModels;
using CRMDev.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CRMDev.Application.HelperFunction
{
    public class HelperFunctions
    {
        public async Task<OpportunityDetailVM> CreateOpportunityDetailVM(CRMDevDbContext _dbContext, int id)
        {
            var opportunity = await _dbContext.Opportunities
                .Include(s => s.Stages)
                    .ThenInclude(t => t.Tasks)
                .Include(c => c.Contact)
                .SingleOrDefaultAsync(o => o.Id == id);

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

        public async Task<ContactDetailVM> CreateContactDetailVM(CRMDevDbContext _dbContext, int id)
        {
            var contactVM = await _dbContext.Contacts
               .Where(c => c.Id == id)
               .Select(c => new ContactDetailVM(
                   c.Name,
                   c.Email,
                   c.Phone,
                   c.CellPhone,
                   c.FieldOrIndustry.FieldName,
                   c.Position,
                   c.Address,
                   c.IsActive.ToString(),
                   c.ContactNotesSummary ?? "N/A",
                   c.Notes)
               )
               .FirstOrDefaultAsync();

            return contactVM;
        }

        public async Task<FieldOrIndustryVM> CreateFieldOrIndustryVM(CRMDevDbContext _dbContext, int id)
        {
            var field = await _dbContext.FieldOrIndustries
                .Where(f => f.Id == id)
                .Select(f => new FieldOrIndustryVM(
                    f.FieldName, 
                    f.Description
                    )
                )
                .SingleOrDefaultAsync();

            return field;
        }

    }
}
