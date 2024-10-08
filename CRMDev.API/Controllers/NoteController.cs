﻿using CRMDev.Application.Command.NoteContactDelete;
using CRMDev.Application.Command.NoteEditContactNote;
using CRMDev.Application.Command.NoteEditTask;
using CRMDev.Application.Command.NotePostContactNote;
using CRMDev.Application.Command.NotePostCurrentTask;
using CRMDev.Application.Command.NoteTaskDelete;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRMDev.API.Controllers
{
    [Route("api/notes")]
    public class NoteController : Controller
    {
        private readonly IMediator _mediator;

        public NoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("contact/{id}")]
        public async Task<IActionResult> PostContactNote(int id, [FromBody] string newNote)
        {
            var command = new PostContactNoteCommand(id, newNote);

            var contact = await _mediator.Send(command);

            return contact == null ? NoContent() : Ok(contact);
        }

        [HttpPost("current-task/{opportunityId}")]
        public async Task<IActionResult> PostCurrentTaskNote(int opportunityId, [FromBody] string newNote)
        {
            var command = new PostCurrentTaskNoteCommand(opportunityId, newNote);

            var opportunity = await _mediator.Send(command);

            return opportunity == null ? NoContent() : Ok(opportunity);
        }

        [HttpPut("edit-contact-note/{ContactId}/{NoteId}")]
        public async Task<IActionResult> EditContactNote(int ContactId, int NoteId, [FromBody] string newNote)
        {
            var command = new EditContactNoteCommand(ContactId, NoteId, newNote);

            var contact = await _mediator.Send(command);

            return contact == null ? NoContent() : Ok(contact);
        }

        [HttpPut("edit-task-note/{OpportunityId}/{TaskId}")]
        public async Task<IActionResult> EditTaskNote(int OpportunityId, int TaskId, [FromBody] string newNote)
        {
            
            var opportunity = new EditTaskNoteCommand(OpportunityId, TaskId, newNote);

            var contact = await _mediator.Send(opportunity);

            return contact == null ? NoContent() : Ok(contact);
        }

        [HttpDelete("delete-contact-note/{contactId}/{noteId}")]
        public async Task<IActionResult> DeleteContactNote(int contactId, int noteId)
        {
            var command = new DeleteContactNoteCommand(contactId, noteId);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("delete-task-note/{OpportunityId}/{TaskId}/{NoteId}")]
        public async Task<IActionResult> DeleteTaskNote(int OpportunityId, int TaskId, int NoteId)
        {
            var command = new DeleteTaskNoteCommand(OpportunityId, TaskId, NoteId);
            await _mediator.Send(command);

            return NoContent();
        }


    }
}
