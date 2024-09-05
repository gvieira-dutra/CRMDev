using CRMDev.Application.HelperFunction;
using CRMDev.Application.ViewModels;
using CRMDev.Core.Entities;
using CRMDev.Infrastructure.Persistence;
using MediatR;

namespace CRMDev.Application.Command.PostOpportunity
{
    public class PostOpportunityCommandHandler : IRequestHandler<PostOpportunityCommand, OpportunityDetailVM>
    {
        private readonly CRMDevDbContext _dbContext;
        private readonly IHelperFunctions _helper;

        public PostOpportunityCommandHandler(CRMDevDbContext dbContext, IHelperFunctions helper)
        {
            _dbContext = dbContext;
            _helper = helper;
        }
        public async Task<OpportunityDetailVM> Handle(PostOpportunityCommand request, CancellationToken cancellationToken)
        {
            var opportunity = new Opportunity(
                request.Title,
                request.Description,
                request.DeliveryEstimate,
                request.Estimative,
                request.Scope,
                request.SupportIncluded,
                request.ContactId
            );

            await _dbContext.Opportunities
                .AddAsync(opportunity, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return await _helper.CreateOpportunityDetailVM(_dbContext, opportunity.Id);
        }
    }
}
