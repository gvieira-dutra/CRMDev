using CRMDev.Core.Entities;

namespace CRMDev.Application.Services.Interfaces
{
    public interface INoteServices
    {
        Contact PostContactNote(int id, string note);
        Opportunity PostCurrentTaskNote(int opportunityId, Note newNote);
        Contact EditContactNote(int ContactId, int NoteId, Note newNote);
        Opportunity EditTaskNote(int OpportunityId, int TaskId, int NoteId, Note newNote);
        void DeleteContactNote(int ContactId, int NoteId);
        void DeleteTaskNote(int OpportunityId, int TaskId, int NoteId);
    }
}
