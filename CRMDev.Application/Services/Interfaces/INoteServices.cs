using CRMDev.Application.ViewModels;
using CRMDev.Core.Entities;

namespace CRMDev.Application.Services.Interfaces
{
    public interface INoteServices
    {
        ContactDetailVM PostContactNote(int id, string note);
        Opportunity PostCurrentTaskNote(int opportunityId, string newNote);
        ContactDetailVM EditContactNote(int ContactId, int NoteId, string newNote);
        Opportunity EditTaskNote(int OpportunityId, int TaskId, string newNote);
        void DeleteContactNote(int ContactId, int NoteId);
        void DeleteTaskNote(int OpportunityId, int TaskId, int NoteId);
    }
}
