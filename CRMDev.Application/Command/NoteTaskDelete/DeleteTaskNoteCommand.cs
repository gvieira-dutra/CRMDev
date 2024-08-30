using MediatR;

namespace CRMDev.Application.Command.NoteTaskDelete
{
    public class DeleteTaskNoteCommand : IRequest<Unit>
    {
        public int OpportunityId { get; set; }
        public int TaskId { get; set; }
        public int NoteId { get; set; }
    }
}
