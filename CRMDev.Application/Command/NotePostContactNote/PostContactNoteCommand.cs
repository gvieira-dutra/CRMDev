using CRMDev.Application.ViewModels;
using MediatR;

namespace CRMDev.Application.Command.NotePostContactNote
{
    public class PostContactNoteCommand : IRequest<ContactDetailVM>
    {
        public int Id { get; set; }
        public string Note { get; set; }
    }
}
