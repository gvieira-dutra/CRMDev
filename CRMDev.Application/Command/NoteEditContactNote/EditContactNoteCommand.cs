using CRMDev.Application.ViewModels;
using MediatR;

namespace CRMDev.Application.Command.NoteEditContactNote
{
    public class EditContactNoteCommand : IRequest<ContactDetailVM>
    {
        public int ContactId { get; set; }
        public int NoteId { get; set; }
        public string NewNote { get; set; }

    }
}
