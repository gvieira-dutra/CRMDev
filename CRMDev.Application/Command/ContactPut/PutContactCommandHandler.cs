using CRMDev.Core.DTO;
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
        private readonly IHelperFunctions _helper;
        public PutContactCommandHandler(CRMDevDbContext dbContext, IHelperFunctions helper)
        {
            _dbContext = dbContext;
            _helper = helper;
        }

        public async Task<ContactDetailVM> Handle(PutContactCommand request, CancellationToken cancellationToken)
        {
            var contactNewInfo = new ContactDTO(
                request.Id,
                request.Name,
                request.Email,
                request.Phone,
                request.CellPhone,
                request.Position,
                request.Address
            );            

            var contactToBeEdited = await _dbContext.Contacts
                .FirstOrDefaultAsync(c => c.Id == request.Id,  cancellationToken);

            contactToBeEdited.EditContact(contactNewInfo);
            _dbContext.Update(contactToBeEdited);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return await _helper.CreateContactDetailVM(_dbContext, request.Id);

        }
    }
}
