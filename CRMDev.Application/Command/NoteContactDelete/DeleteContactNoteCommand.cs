using MediatR;

namespace CRMDev.Application.Command.NoteContactDelete
{
    public class DeleteContactNoteCommand : IRequest<Unit>
    {
        public int ContactId { get; set; }
        public int NoteId { get; set; }
    }
}
