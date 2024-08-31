using CRMDev.Application.HelperFunction;
using CRMDev.Application.ViewModels;
using CRMDev.Core.Entities;
using CRMDev.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRMDev.Application.Command.ContactPost
{
    public class PostContactCommandHandler : IRequestHandler<PostContactCommand, ContactDetailVM>
    {
        private readonly CRMDevDbContext _dbContext;
        private readonly HelperFunctions _helper;
        public PostContactCommandHandler(CRMDevDbContext dbContext, HelperFunctions helper)
        {
            _dbContext = dbContext;
            _helper = helper;
        }

        public async Task<ContactDetailVM> Handle(PostContactCommand request, CancellationToken cancellationToken)
        {
            var field = await _dbContext.FieldOrIndustries
                .Where(f => f.Id == request.FieldOrIndustryId)
                .FirstOrDefaultAsync(cancellationToken);

            var contact = new Contact(request.Name, request.Email, request.Phone, request.CellPhone, field, request.Position, request.Address);

            await _dbContext.Contacts
                .AddAsync(contact);

            await _dbContext.SaveChangesAsync();

            return await _helper.CreateContactDetailVM(_dbContext, contact.Id);
        }
    }
}
