using CRMDev.Application.ViewModels;
using MediatR;

namespace CRMDev.Application.Command.NotePostContactNote
{
    public class PostContactNoteCommand(int id, string note) : IRequest<ContactDetailVM>
    {
        public int Id { get; set; } = id;
        public string Note { get; set; } = note;
    }
}
