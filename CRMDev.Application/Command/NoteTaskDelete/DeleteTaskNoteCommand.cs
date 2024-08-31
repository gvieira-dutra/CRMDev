using MediatR;

namespace CRMDev.Application.Command.NoteTaskDelete
{
    public class DeleteTaskNoteCommand(int opportunityId, int taskId, int noteId) : IRequest<Unit>
    {
        public int OpportunityId { get; set; } = opportunityId;
        public int TaskId { get; set; } = taskId;
        public int NoteId { get; set; } = noteId;
    }
}
