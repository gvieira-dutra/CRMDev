using CRMDev.Application.Services.Interfaces;
using CRMDev.Core.Entities;
using CRMDev.Infrastructure.Persistence;

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
                .FirstOrDefault(c => c.Id == contactId);

            var note = contact
                .Notes
                .FirstOrDefault(n => n.Id == noteId);

            contact.Notes.Remove(note);
        }

        public void DeleteTaskNote(int opportunityId, int taskId, int noteId)
        {
            var opp = _dbContext.Opportunities
               .FirstOrDefault(o => o.Id == opportunityId);

            var task = opp
                .Stages[opp.CurrentStageTracker]
                .Tasks
                .FirstOrDefault(t => t.Id == opp.CurrentTaskTracker);

            var taskNote = task
                .Notes
                .FirstOrDefault(n => n.Id == noteId);

            task.Notes.Remove(taskNote);

        }

        public Contact EditContactNote(int contactId, int noteId, BaseNote newNote)
        {
            var contact = _dbContext.Contacts
                .FirstOrDefault(c => c.Id == contactId);

            var note = contact.Notes
                .FirstOrDefault(n => n.Id == noteId);

            note.EditNoteContent(newNote.Content);

            return contact;
        }

        public Opportunity EditTaskNote(int OpportunityId, int TaskId, int noteId, BaseNote newNote)
        {
            var opp = _dbContext.Opportunities
                .FirstOrDefault(o => o.Id == OpportunityId);

            var taskNote = opp
                .Stages[opp.CurrentStageTracker]
                .Tasks[TaskId]
                .Notes
                .FirstOrDefault(n => n.Id == noteId);

            taskNote.EditNoteContent(newNote.Content);

            return opp;
               
        }

        public Contact PostContactNote(int id, string note)
        {
            var contact = _dbContext.Contacts
                .FirstOrDefault(c => c.Id == id);

            var newNote = new ContactNote(contact, note);
            
            contact?.AddContactNote(newNote);

            return contact;
        }

        public Opportunity PostCurrentTaskNote(int opportunityId, string newNote)
        {
            var opportunity = _dbContext.Opportunities
                .FirstOrDefault(o => o.Id == opportunityId);

            var currTask = opportunity.Stages[opportunity.CurrentStageTracker].Tasks[opportunity.CurrentTaskTracker];

            var note = new TaskNote(currTask, newNote);

            currTask.AddTaskNote(note);

            return opportunity;
        }
    }
}
