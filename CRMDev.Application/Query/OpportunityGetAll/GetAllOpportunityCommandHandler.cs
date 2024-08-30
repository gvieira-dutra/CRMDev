using CRMDev.Application.ViewModels;
using CRMDev.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRMDev.Application.Query.OpportunityGetAll
{
    public class GetAllOpportunityCommandHandler : IRequestHandler<GetAllOpportunityCommand, List<OpportunityVM>>
    {
        private readonly CRMDevDbContext _dbContext;
        public GetAllOpportunityCommandHandler(CRMDevDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<OpportunityVM>> Handle(GetAllOpportunityCommand request, CancellationToken cancellationToken)
        {
            var opportunities = await _dbContext.Opportunities
                .Select(o => new OpportunityVM(
                    o.Id, 
                    o.Title, 
                    o.Description, 
                    o.Estimative
                ))
                .ToListAsync(cancellationToken: cancellationToken);

            return opportunities;
        }
    }
}
