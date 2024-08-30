using CRMDev.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRMDev.Application.Command.NoteTaskDelete
{
    public class DeleteTaskNoteCommandHandler : IRequestHandler<DeleteTaskNoteCommand, Unit>
    {
        private readonly CRMDevDbContext _dbContext;
        public DeleteTaskNoteCommandHandler(CRMDevDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteTaskNoteCommand request, CancellationToken cancellationToken)
        {
            var taskNote = await _dbContext.TaskNotes
                .Include(t => t.Task)
                .SingleOrDefaultAsync(n => n.Id == request.NoteId, cancellationToken: cancellationToken);

            var task = await _dbContext.Tasks
                .Include(t => t.TaskNotes)
                .SingleOrDefaultAsync(t => t.Id == request.TaskId, cancellationToken: cancellationToken);

            task.TaskNotes.Remove(taskNote);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
