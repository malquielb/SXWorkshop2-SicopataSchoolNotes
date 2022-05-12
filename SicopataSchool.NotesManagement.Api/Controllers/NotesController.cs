using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SicopataSchool.NotesManagement.Application.Features.Notes.Commands.CreateNote;
using SicopataSchool.NotesManagement.Application.Features.Notes.Commands.DeleteNote;
using SicopataSchool.NotesManagement.Application.Features.Notes.Commands.ShareNote;
using SicopataSchool.NotesManagement.Application.Features.Notes.Commands.UpdateNote;
using SicopataSchool.NotesManagement.Application.Features.Notes.Queries.GetNoteDetails;
using SicopataSchool.NotesManagement.Application.Features.Notes.Queries.GetNotesList;
using SicopataSchool.NotesManagement.Application.Features.Notes.Queries.GetPublicNotes;

namespace SicopataSchool.NotesManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [EnableQuery(PageSize = 25)]
        public async Task<ActionResult<List<ListNoteVm>>> GetNoteList()
        {
            var response = await _mediator.Send(new GetNotesListQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<NoteDetailsVm>> GetNoteDetails(int id)
        {
            var response = await _mediator.Send(new GetNoteDetailsQuery() { Id = id });
            return Ok(response);
        }

        [HttpGet]
        [Route("public")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [EnableQuery(PageSize = 25)]
        public async Task<ActionResult<List<PublicNoteVm>>> GetPublicNotes()
        {
            var response = await _mediator.Send(new GetPublicNotesQuery());
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CreateNoteResponseVm>> CreateNote(CreateNoteCommand createNote)
        {
            var response = await _mediator.Send(createNote);
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPost()]
        [Route("share")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> ShareNote(int noteId, int studentId)
        {
            await _mediator.Send(new ShareNoteCommand { NoteId = noteId, StudentId = studentId });
            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateNote(UpdateNoteCommand updateNote)
        {
            await _mediator.Send(updateNote);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteNote(int id)
        {
            await _mediator.Send(new DeleteNoteCommand() { Id = id });
            return NoContent();
        }
    }
}
