using CRMDev.Application.HelperFunction;
using CRMDev.Application.ViewModels;
using CRMDev.Infrastructure.Persistence;
using MediatR;

namespace CRMDev.Application.Query.FieldGetOne
{
    public class GetOneFieldCommandHandler : IRequestHandler<GetOneFieldCommand, FieldOrIndustryVM>
    {
        private readonly CRMDevDbContext _dbContext;
        private readonly HelperFunctions _helper;
        public GetOneFieldCommandHandler(CRMDevDbContext dbContext, HelperFunctions helper)
        {
            _dbContext = dbContext;
            _helper = helper;
        }

        public async Task<FieldOrIndustryVM> Handle(GetOneFieldCommand request, CancellationToken cancellationToken)
        {
            return await _helper.CreateFieldOrIndustryVM(_dbContext, request.Id);
        }
    }
}
