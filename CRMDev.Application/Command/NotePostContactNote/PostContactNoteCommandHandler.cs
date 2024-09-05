using CRMDev.Application.HelperFunction;
using CRMDev.Application.ViewModels;
using CRMDev.Core.Entities;
using CRMDev.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRMDev.Application.Command.NotePostContactNote
{
    internal class PostContactNoteCommandHandler : IRequestHandler<PostContactNoteCommand, ContactDetailVM>
    {
        private readonly CRMDevDbContext _dbContext;
        private readonly IHelperFunctions _helper;
        public PostContactNoteCommandHandler(CRMDevDbContext dbContext, IHelperFunctions helper)
        {
            _dbContext = dbContext;
            _helper = helper;
        }
        public async Task<ContactDetailVM> Handle(PostContactNoteCommand request, CancellationToken cancellationToken)
        {
            var contact = await _dbContext.Contacts
                .Include(f => f.FieldOrIndustry)
                .Include(n => n.Notes)
                .Include(o => o.Opportunities)
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken: cancellationToken);

            var newNote = new ContactNote(contact, request.Note);

            contact?.AddContactNote(newNote);

            var summary = await _helper.CreateContactNotesSummary(contact.Notes);

            contact.UpdateContactNotesSummary(summary);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return await _helper.CreateContactDetailVM(_dbContext, request.Id);
        }
    }
}
