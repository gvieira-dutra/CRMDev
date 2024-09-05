using CRMDev.Application.HelperFunction;
using CRMDev.Application.ViewModels;
using CRMDev.Core.Entities;
using CRMDev.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRMDev.Application.Command.FieldPut
{
    public class PutFieldCommandHandler : IRequestHandler<PutFieldCommand, FieldOrIndustryVM>
    {
        private readonly CRMDevDbContext _dbContext;
        private readonly IHelperFunctions _helper;
        public PutFieldCommandHandler(CRMDevDbContext dbContext, IHelperFunctions helper)
        {
            _dbContext = dbContext;
            _helper = helper;
        }
        public async Task<FieldOrIndustryVM> Handle(PutFieldCommand request, CancellationToken cancellationToken)
        {
            var fieldToBeEdited = await _dbContext.FieldOrIndustries
                .Where(f => f.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken: cancellationToken);

            var fieldNewInfo = new FieldOrIndustry
                (
                    request.FieldName,
                    request.Description
                );

            fieldToBeEdited?.EditField(fieldNewInfo);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return await _helper.CreateFieldOrIndustryVM(_dbContext, request.Id);
        }
    }
}
