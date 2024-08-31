using MediatR;

namespace CRMDev.Application.Command.NoteContactDelete
{
    public class DeleteContactNoteCommand(int contactId, int noteId) : IRequest<Unit>
    {
        public int ContactId { get; set; } = contactId;
        public int NoteId { get; set; } = noteId;
    }
}
