using CRMDev.Application.InputModels;
using CRMDev.Application.ViewModels;

namespace CRMDev.Application.Services.Interfaces
{
    public interface IOpportunityServices
    {
        List<OpportunityVM> GetAll(string query);
        OpportunityDetailVM GetOne(int id);
        OpportunityDetailVM Post(CreateOpportunityInputModel opportunity);
        OpportunityDetailVM Put(EditOpportunityInputModel opportunity);
        OpportunityDetailVM CompleteTask(int id);
        void Delete(int id);
    }
}
