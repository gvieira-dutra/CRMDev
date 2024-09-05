using CRMDev.Application.HelperFunction;
using CRMDev.Application.ViewModels;
using CRMDev.Core.Entities;
using CRMDev.Infrastructure.Persistence;
using MediatR;

namespace CRMDev.Application.Command.FieldPost
{
    public class PostFieldCommandHandler : IRequestHandler<PostFieldCommand, FieldOrIndustryVM>
    {
        private readonly CRMDevDbContext _dbContext;
        private readonly IHelperFunctions _helper;

        public PostFieldCommandHandler(CRMDevDbContext dbContext, IHelperFunctions helper)
        {
            _dbContext = dbContext;
            _helper = helper;
        }

        public async Task<FieldOrIndustryVM> Handle(PostFieldCommand request, CancellationToken cancellationToken)
        {
            var field = new FieldOrIndustry(
                request.FieldName,
                request.Description
            );

            await _dbContext.FieldOrIndustries
                .AddAsync(field, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return await _helper.CreateFieldOrIndustryVM(_dbContext, field.Id);
        }

    }
}
