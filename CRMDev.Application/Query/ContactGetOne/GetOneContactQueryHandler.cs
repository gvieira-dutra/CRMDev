using CRMDev.Application.HelperFunction;
using CRMDev.Application.ViewModels;
using CRMDev.Infrastructure.Persistence;
using MediatR;

namespace CRMDev.Application.Query.ContactGetOne
{
    internal class GetOneContactQueryHandler : IRequestHandler<GetOneContactQuery, ContactDetailVM>
    {
        private readonly CRMDevDbContext _dbContext;
        private readonly IHelperFunctions _helper;
        public GetOneContactQueryHandler(CRMDevDbContext dbContext, IHelperFunctions helper)
        {
            _dbContext = dbContext;
            _helper = helper;
        }
        public async Task<ContactDetailVM> Handle(GetOneContactQuery request, CancellationToken cancellationToken)
        {
            return await _helper.CreateContactDetailVM(_dbContext, request.Id);
        }
    }
}
