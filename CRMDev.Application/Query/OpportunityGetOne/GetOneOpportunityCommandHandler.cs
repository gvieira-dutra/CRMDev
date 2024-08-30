using CRMDev.Application.HelperFunction;
using CRMDev.Application.ViewModels;
using CRMDev.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRMDev.Application.Query.OpportunityGetOne
{
    public class GetOneOpportunityCommandHandler : IRequestHandler<GetOneOpportunityCommand, OpportunityDetailVM>
    {
        private readonly CRMDevDbContext _dbContext;
        private readonly HelperFunctions _helper;

        public GetOneOpportunityCommandHandler(CRMDevDbContext dbContext, HelperFunctions helper)
        {
            _dbContext = dbContext;
            _helper = helper;
        }
        public async Task<OpportunityDetailVM> Handle(GetOneOpportunityCommand request, CancellationToken cancellationToken)
        {
            var opportunity = await _dbContext.Opportunities
                .Include(s => s.Stages)
                    .ThenInclude(t => t.Tasks)
                .Include(c => c.Contact)
                .SingleOrDefaultAsync(o => o.Id == request.Id, cancellationToken: cancellationToken);

            return await _helper.CreateOpportunityDetailVM(_dbContext, request.Id);
        }
    }
}
