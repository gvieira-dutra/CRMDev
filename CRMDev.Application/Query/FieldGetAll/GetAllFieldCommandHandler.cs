using CRMDev.Application.ViewModels;
using CRMDev.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRMDev.Application.Query.FieldGetAll
{
    public class GetAllFieldCommandHandler : IRequestHandler<GetAllFieldCommand, List<FieldOrIndustryVM>>
    {
        private readonly CRMDevDbContext _dbContext;
        public GetAllFieldCommandHandler(CRMDevDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<FieldOrIndustryVM>> Handle(GetAllFieldCommand request, CancellationToken cancellationToken)
        {
            var fields = await _dbContext.FieldOrIndustries
                .Select(f => new FieldOrIndustryVM(
                    f.FieldName,
                    f.Description)
                )
                .ToListAsync(cancellationToken: cancellationToken);

            return fields;
        }
    }
}
