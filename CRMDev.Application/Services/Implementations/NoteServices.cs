using CRMDev.Application.Services.Interfaces;
using CRMDev.Application.ViewModels;
using CRMDev.Core.Entities;
using CRMDev.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CRMDev.Application.Services.Implementations
{
    public class NoteServices : INoteServices
    {
        private readonly CRMDevDbContext _dbContext;

        public NoteServices(CRMDevDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteContactNote(int contactId, int noteId)
        {
            var contact = _dbContext.Contacts
                .Include(n => n.Notes)
                .FirstOrDefault(c => c.Id == contactId);

            var note = contact
                .Notes
                .FirstOrDefault(n => n.Id == noteId);

            contact.Notes.Remove(note);

            _dbContext.SaveChanges();
        }

        public void DeleteTaskNote(int opportunityId, int taskId, int noteId)
        {
            var taskNote = _dbContext.TaskNotes
                .Include(t => t.Task)
                .SingleOrDefault(n => n.Id == noteId);

            var task = _dbContext.Tasks
                .Include(t => t.TaskNotes)
                .SingleOrDefault(t => t.Id == taskId);



            task.TaskNotes.Remove(taskNote);

            _dbContext.SaveChanges();
        }

        public ContactDetailVM EditContactNote(int contactId, int noteId, string newNote)
        {
            var contact = _dbContext.Contacts
                .Include(c => c.Notes)
                .FirstOrDefault(c => c.Id == contactId);

            var note = contact.Notes
                .FirstOrDefault(n => n.Id == noteId);

            note.EditNoteContent(newNote);

            _dbContext.SaveChanges();

            return CreateContactDetailVM(contact.Id);
        }

        public Opportunity EditTaskNote(int OpportunityId, int TaskId, string newNote)
        {

            var tNote = _dbContext.TaskNotes
                .Include(t => t.Task)
                .FirstOrDefault(t => t.TaskId == TaskId);

            tNote.EditNoteContent(newNote);

            _dbContext.SaveChanges();

            var opp = _dbContext.Opportunities
                .Include(s => s.Stages)
                    .ThenInclude(t => t.Tasks)
                .FirstOrDefault(o => o.Id == OpportunityId);

            return opp;              
        }

        public ContactDetailVM PostContactNote(int id, string note)
        {
            var contact = _dbContext?.Contacts
                .Include(f => f.FieldOrIndustry)
                .Include(n => n.Notes)
                .Include(o => o.Opportunities)
                .FirstOrDefault(c => c.Id == id);

            var newNote = new ContactNote(contact, note);
            
            contact?.AddContactNote(newNote);

            _dbContext.SaveChanges();

            return CreateContactDetailVM(contact.Id);
        }

        public Opportunity PostCurrentTaskNote(int opportunityId, string newNote)
        {
            var opportunity = _dbContext.Opportunities
                .Include(c => c.Contact)
                .Include(s => s.Stages)
                    .ThenInclude(t => t.Tasks)
                    .ThenInclude(t => t.TaskNotes)
                .FirstOrDefault(o => o.Id == opportunityId);

            var currTask = opportunity.Stages[opportunity.CurrentStageTracker].Tasks[opportunity.CurrentTaskTracker];

            var note = new TaskNote(currTask, newNote);

            currTask.AddTaskNote(note);

            _dbContext.SaveChanges();

            return opportunity;
        }
    
        private ContactDetailVM CreateContactDetailVM(int id)
        {
            var contactVM = _dbContext.Contacts
               .Where(c => c.Id == id)
               .Select(c => new ContactDetailVM(
                   c.Name,
                   c.Email,
                   c.Phone,
                   c.CellPhone,
                   c.FieldOrIndustry.FieldName,
                   c.Position,
                   c.Address,
                   c.IsActive.ToString(),
                   c.Notes)
               )
               .FirstOrDefault();

                return contactVM;
        }
    
    }
}
