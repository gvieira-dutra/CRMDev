using CRMDev.Application.HelperFunction;
using CRMDev.Application.ViewModels;
using CRMDev.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRMDev.Application.Command.OpportunitySetStatusClosed
{
    public class SetStatusClosedCommandHandler : IRequestHandler<SetStatusClosedCommand, OpportunityDetailVM>
    {
        private readonly CRMDevDbContext _dbContext;
        private readonly IHelperFunctions _helper;
        public SetStatusClosedCommandHandler(CRMDevDbContext dbContext, IHelperFunctions helper)
        {
            _dbContext = dbContext;
            _helper = helper;
        }
        public async Task<OpportunityDetailVM> Handle(SetStatusClosedCommand request, CancellationToken cancellationToken)
        {
            var opportunity = await _dbContext.Opportunities
               .Include(s => s.Stages)
                   .ThenInclude(t => t.Tasks)
               .Include(c => c.Contact)
               .SingleOrDefaultAsync(o => o.Id == request.Id, cancellationToken: cancellationToken);

            opportunity.SetStatusClosed();

            await _dbContext.SaveChangesAsync(cancellationToken);

            return await _helper.CreateOpportunityDetailVM(_dbContext, request.Id);
        }
    }
}
