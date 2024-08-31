using CRMDev.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRMDev.Application.Command.ContactDelete
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Unit>
    {
        private readonly CRMDevDbContext _dbContext;
        public DeleteContactCommandHandler(CRMDevDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _dbContext.Contacts
                .Where(a => a.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            contact?.DeleteContact();

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
