using CRMDev.Application.ViewModels;
using MediatR;

namespace CRMDev.Application.Command.NoteEditContactNote
{
    public class EditContactNoteCommand(int contactId, int noteId, string newNote) : IRequest<ContactDetailVM>
    {
        public int ContactId { get; set; } = contactId;
        public int NoteId { get; set; } = noteId;
        public string NewNote { get; set; } = newNote;

    }
}
