using CRMDev.Application.HelperFunction;
using CRMDev.Application.ViewModels;
using CRMDev.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRMDev.Application.Query.ContactGetAll
{
    public class GetAllContactQueryHandler : IRequestHandler<GetAllContactQuery, List<ContactVM>>
    {
        private readonly CRMDevDbContext _dbContext;
        private readonly HelperFunctions _helper;
        public GetAllContactQueryHandler(CRMDevDbContext dbContext, HelperFunctions helper)
        {
            _dbContext = dbContext;
            _helper = helper;
        }
        public async Task<List<ContactVM>> Handle(GetAllContactQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _dbContext.Contacts
                .Where(c => c.IsActive == true)
                .Select(c => new ContactVM(c.Name, c.Email, c.Phone, c.FieldOrIndustry.FieldName, c.Position))
                .ToListAsync(cancellationToken: cancellationToken);

            return contacts;
        }
    }
}
