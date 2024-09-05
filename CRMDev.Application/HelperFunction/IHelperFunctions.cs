using CRMDev.Application.ViewModels;
using CRMDev.Core.Entities;
using CRMDev.Infrastructure.Persistence;

namespace CRMDev.Application.HelperFunction
{
    public interface IHelperFunctions
    {
        Task<OpportunityDetailVM> CreateOpportunityDetailVM(CRMDevDbContext _dbContext, int id);
        Task<ContactDetailVM> CreateContactDetailVM(CRMDevDbContext _dbContext, int id);
        Task<FieldOrIndustryVM> CreateFieldOrIndustryVM(CRMDevDbContext _dbContext, int id);

        Task<string> CreateContactNotesSummary(List<ContactNote> notes);
    }
}
