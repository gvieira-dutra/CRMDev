using CRMDev.Application.HelperFunction;
using CRMDev.Application.ViewModels;
using CRMDev.Core.Entities;
using CRMDev.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRMDev.Application.Command.NoteEditContactNote
{ 
    public class EditContactNoteCommandHandler : IRequestHandler<EditContactNoteCommand, ContactDetailVM>
    {
        private readonly CRMDevDbContext _dbContext;
        private readonly HelperFunctions _helper;
        public EditContactNoteCommandHandler(CRMDevDbContext dbContext, HelperFunctions helper)
        {
            _dbContext = dbContext;
            _helper = helper;
        }

        public async Task<ContactDetailVM> Handle(EditContactNoteCommand request, CancellationToken cancellationToken)
        {
            var contact = await _dbContext.Contacts
                .Include(c => c.Notes)
                .FirstOrDefaultAsync(c => c.Id == request.ContactId);

            var note = contact.Notes
                .FirstOrDefault(n => n.Id == request.NoteId);

            note.EditNoteContent(request.NewNote);

            await _dbContext.SaveChangesAsync();

            return await _helper.CreateContactDetailVM(_dbContext, contact.Id);
        }
    }
}
