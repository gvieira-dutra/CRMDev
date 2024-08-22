using CRMDev.Application.Services.Interfaces;
using CRMDev.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRMDev.API.Controllers
{
    [Route("api/notes")]
    public class NoteController : Controller
    {
        private readonly INoteServices _service;

        public NoteController(INoteServices service)
        {
            _service = service;
        }

        [HttpPost("contact/{id}")]
        public IActionResult PostContactNote(int id, [FromBody] string newNote)
        {
            return Ok(_service.PostContactNote(id, newNote));
        }

        [HttpPost("current-task/{opportunityId}")]
        public IActionResult PostCurrentTaskNote(int opportunityId, [FromBody] Note newNote)
        {
            return Ok(_service.PostCurrentTaskNote(opportunityId, newNote));
        }

        [HttpPut("edit-contact-note/{ContactId}/{NoteId}")]
        public IActionResult EditContactNote(int ContactId, int NoteId, [FromBody] Note newNote)
        {
            return Ok(_service.EditContactNote(ContactId, NoteId, newNote));
        }

        [HttpPut("edit-task-note/{OpportunityId}/{TaskId}/{NoteId}")]
        public IActionResult EditTaskNote(int OpportunityId, int TaskId, int NoteId, [FromBody] Note newNote)
        {
            return Ok(_service.EditTaskNote(OpportunityId, TaskId, NoteId, newNote));
        }

        [HttpDelete("delete-contact-note/{ContactId}/{NoteId}")]
        public IActionResult DeleteContactNote(int contactId, int noteId)
        {
            _service.DeleteContactNote(contactId, noteId);
            return Ok();
        }

        [HttpDelete("delete-task-note/{OpportunityId}/{TaskId}/{NoteId}")]
        public IActionResult DeleteTaskNote(int OpportunityId, int TaskId, int NoteId)
        {
            _service.DeleteTaskNote(OpportunityId, TaskId, NoteId);

            return NoContent();
        }


    }
}
