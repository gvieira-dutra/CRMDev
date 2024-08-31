using CRMDev.Application.ViewModels;
using MediatR;

namespace CRMDev.Application.Command.NotePostCurrentTask
{
    public class PostCurrentTaskNoteCommand(int opportunityId, string newNote) : IRequest<OpportunityDetailVM>
    {
        public int OpportunityId { get; set; } = opportunityId;
        public string NewNote { get; set; } = newNote;
    }
}
