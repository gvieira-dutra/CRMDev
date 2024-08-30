using CRMDev.Application.ViewModels;
using MediatR;

namespace CRMDev.Application.Command.NotePostCurrentTask
{
    public class PostCurrentTaskNoteCommand : IRequest<OpportunityDetailVM>
    {
        public int OpportunityId { get; set; }
        public string NewNote { get; set; }
    }
}
