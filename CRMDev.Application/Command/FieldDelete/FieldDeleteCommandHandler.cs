using CRMDev.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRMDev.Application.Command.FieldDelete
{
    public class FieldDeleteCommandHandler : IRequestHandler<FieldDeleteCommand, Unit>
    {
        private readonly CRMDevDbContext _dbContext;
        public FieldDeleteCommandHandler(CRMDevDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(FieldDeleteCommand request, CancellationToken cancellationToken)
        {
            var toBeDeleted = await _dbContext.FieldOrIndustries
                .Where(f => f.Id == request.Id)
                 .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            _dbContext.FieldOrIndustries.Remove(toBeDeleted);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
