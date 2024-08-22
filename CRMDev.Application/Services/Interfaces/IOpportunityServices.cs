using CRMDev.Application.InputModels;
using CRMDev.Application.ViewModels;
using CRMDev.Core.Enums;

namespace CRMDev.Application.Services.Interfaces
{
    public interface IOpportunityServices
    {
        List<OpportunityVM> GetAll(string query);
        OpportunityDetailVM GetOne(int id);
        OpportunityDetailVM Post(CreateOpportunityInputModel opportunity);
        OpportunityDetailVM Put(int id, EditOpportunityInputModel opportunity);
        OpportunityDetailVM CompleteCurrentTask(int id);
        OpportunityDetailVM SetStatusClosed(int id);
        public OpportunityDetailVM SetStatusLost(int id, ReasonForLostDeal reason);
    }
}
