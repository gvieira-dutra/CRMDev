using CRMDev.Application.HelperFunction;
using CRMDev.Application.ViewModels;
using CRMDev.Core.Entities;
using CRMDev.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRMDev.Application.Command.PostOpportunity
{
    public class PutOpportunityCommandHandler : IRequestHandler<PutOpportunityCommand, OpportunityDetailVM>
    {
        private readonly CRMDevDbContext _dbContext;
        private readonly HelperFunctions _helper;

        public PutOpportunityCommandHandler(CRMDevDbContext dbContext, HelperFunctions helper)
        {
            _dbContext = dbContext;
            _helper = helper;
        }
        public async Task<OpportunityDetailVM> Handle(PutOpportunityCommand request, CancellationToken cancellationToken)
        {
            var oppToBeEdited = await _dbContext.Opportunities
               .Include(s => s.Stages)
                   .ThenInclude(t => t.Tasks)
               .Include(c => c.Contact)
               .SingleOrDefaultAsync(o => o.Id == request.Id, cancellationToken: cancellationToken);

            var opp = new Opportunity(
            request.Title,
                request.Description,
                request.DeliveryEstimate,
                request.Estimative,
                request.Scope,
                request.SupportIncluded
            );

            oppToBeEdited.EditOpportunity(opp);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return await _helper.CreateOpportunityDetailVM(_dbContext, request.Id);
        }
    }
}
