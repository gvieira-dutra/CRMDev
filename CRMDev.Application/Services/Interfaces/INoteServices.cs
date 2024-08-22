using CRMDev.Core.Entities;

namespace CRMDev.Application.Services.Interfaces
{
    public interface INoteServices
    {
        Contact PostContactNote(int id, string note);
        Opportunity PostCurrentTaskNote(int opportunityId, string newNote);
        Contact EditContactNote(int ContactId, int NoteId, BaseNote newNote);
        Opportunity EditTaskNote(int OpportunityId, int TaskId, int NoteId, BaseNote newNote);
        void DeleteContactNote(int ContactId, int NoteId);
        void DeleteTaskNote(int OpportunityId, int TaskId, int NoteId);
    }
}
