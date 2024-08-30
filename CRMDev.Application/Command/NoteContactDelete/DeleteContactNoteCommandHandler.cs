using CRMDev.Application.HelperFunction;
using CRMDev.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRMDev.Application.Command.NoteContactDelete
{
    public class DeleteContactNoteCommandHandler : IRequestHandler<DeleteContactNoteCommand, Unit>
    {
        private readonly CRMDevDbContext _dbContext;
        public DeleteContactNoteCommandHandler(CRMDevDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteContactNoteCommand request, CancellationToken cancellationToken)
        {
            var contact = await _dbContext.Contacts
                .Include(n => n.Notes)
                .FirstOrDefaultAsync(c => c.Id == request.ContactId, cancellationToken: cancellationToken);

            var note = contact
                .Notes
                .FirstOrDefault(n => n.Id == request.NoteId);

            contact.Notes.Remove(note);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
