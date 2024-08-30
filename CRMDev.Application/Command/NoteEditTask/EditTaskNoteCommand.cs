using CRMDev.Application.ViewModels;
using MediatR;

namespace CRMDev.Application.Command.NoteEditTask
{
    public class EditTaskNoteCommand : IRequest<OpportunityDetailVM>
    {
        public int OpportunityId { get; set; }
        public int TaskId { get; set; }
        public string NewNote { get; set; }
    }
}
