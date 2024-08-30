﻿using CRMDev.Application.HelperFunction;
using CRMDev.Application.ViewModels;
using CRMDev.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRMDev.Application.Command.OpportunitySetStatusLost
{
    public class SetStatusLostCommandHandler : IRequestHandler<SetStatusLostCommand, OpportunityDetailVM>
    {
        private readonly CRMDevDbContext _dbContext;
        private readonly HelperFunctions _helper;
        public SetStatusLostCommandHandler(CRMDevDbContext dbContext, HelperFunctions helper)
        {
            _dbContext = dbContext;
            _helper = helper;
        }
        public async Task<OpportunityDetailVM> Handle(SetStatusLostCommand request, CancellationToken cancellationToken)
        {
            var opportunity = await _dbContext.Opportunities
               .Include(s => s.Stages)
                   .ThenInclude(t => t.Tasks)
               .Include(c => c.Contact)
               .SingleOrDefaultAsync(o => o.Id == request.Id);

            opportunity.SetStatusLost(request.Reason);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return await _helper.CreateOpportunityDetailVM(_dbContext, request.Id);
        }
    }
}
