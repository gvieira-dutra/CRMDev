using CRMDev.Application.HelperFunction;
using CRMDev.Application.ViewModels;
using CRMDev.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRMDev.Application.Command.NoteEditTask
{
    public class EditTaskNoteCommandHandler : IRequestHandler<EditTaskNoteCommand, OpportunityDetailVM>
    {
        private readonly CRMDevDbContext _dbContext;
        private readonly IHelperFunctions _helper;
        public EditTaskNoteCommandHandler(CRMDevDbContext dbContext, IHelperFunctions helper)
        {
            _dbContext = dbContext;
            _helper = helper;
        }

        public async Task<OpportunityDetailVM> Handle(EditTaskNoteCommand request, CancellationToken cancellationToken)
        {
            var tNote = await _dbContext.TaskNotes
                .Include(t => t.Task)
                .FirstOrDefaultAsync(t => t.TaskId == request.TaskId, cancellationToken: cancellationToken);

            tNote.EditNoteContent(request.NewNote);

            await _dbContext.SaveChangesAsync();

            var opp = _dbContext.Opportunities
                .Include(s => s.Stages)
                    .ThenInclude(t => t.Tasks)
                .FirstOrDefault(o => o.Id == request.OpportunityId);

            return await _helper.CreateOpportunityDetailVM(_dbContext, opp.Id);
        }
    }
}
