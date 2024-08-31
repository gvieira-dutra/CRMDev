using CRMDev.Application.HelperFunction;
using CRMDev.Application.ViewModels;
using CRMDev.Core.Entities;
using CRMDev.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRMDev.Application.Command.ContactPut
{
    public class PutContactCommandHandler : IRequestHandler<PutContactCommand, ContactDetailVM>
    {
        private readonly CRMDevDbContext _dbContext;
        private readonly HelperFunctions _helper;
        public PutContactCommandHandler(CRMDevDbContext dbContext, HelperFunctions helper)
        {
            _dbContext = dbContext;
            _helper = helper;
        }

        public async Task<ContactDetailVM> Handle(PutContactCommand request, CancellationToken cancellationToken)
        {
            var contactNewInfo = new Contact(
                request.Name,
                 request.Email,
                request.Phone,
                request.CellPhone,
                request.FieldOrIndustry,
                request.Position,
                request.Address
            );

            var contactToBeEdited = await _dbContext.Contacts
                .Where(c => c.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            contactToBeEdited.EditContact(contactNewInfo);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return await _helper.CreateContactDetailVM(_dbContext, contactToBeEdited.Id);
        }
    }
}
