using CRMDev.Application.HelperFunction;
using CRMDev.Application.ViewModels;
using CRMDev.Core.Entities;
using CRMDev.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRMDev.Application.Command.NotePostCurrentTask
{
    public class PostCurrentTaskNoteCommandHandler : IRequestHandler<PostCurrentTaskNoteCommand, OpportunityDetailVM>
    {
        private readonly CRMDevDbContext _dbContext;
        private readonly IHelperFunctions _helper;
        public PostCurrentTaskNoteCommandHandler(CRMDevDbContext dbContext, IHelperFunctions helper)
        {
            _dbContext = dbContext;
            _helper = helper;
        }
        public async Task<OpportunityDetailVM> Handle(PostCurrentTaskNoteCommand request, CancellationToken cancellationToken)
        {
            var opportunity = await _dbContext.Opportunities
               .Include(c => c.Contact)
               .Include(s => s.Stages)
                   .ThenInclude(t => t.Tasks)
                   .ThenInclude(t => t.TaskNotes)
               .FirstOrDefaultAsync(o => o.Id == request.OpportunityId, cancellationToken: cancellationToken);

            var currTask = opportunity.Stages[opportunity.CurrentStageTracker].Tasks[opportunity.CurrentTaskTracker];

            var note = new TaskNote(currTask, request.NewNote);

            currTask.AddTaskNote(note);

            await _dbContext.SaveChangesAsync(cancellationToken: cancellationToken);

            return await _helper.CreateOpportunityDetailVM(_dbContext, opportunity.Id);
        }
    }
}
