using CRMDev.Application.ViewModels;
using MediatR;

namespace CRMDev.Application.Command.NoteEditTask
{
    public class EditTaskNoteCommand(int opportunityId, int taskId, string newNote) : IRequest<OpportunityDetailVM>
    {
        public int OpportunityId { get; set; } = opportunityId;
        public int TaskId { get; set; } = taskId;
        public string NewNote { get; set; } = newNote;
    }
}
