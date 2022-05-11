using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SicopataSchool.NotesManagement.Application.Features.Students.Commands.CreateStudent;
using SicopataSchool.NotesManagement.Application.Features.Students.Queries.GetStudentDetails;

namespace SicopataSchool.NotesManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CreateStudentResponseVm>> CreateStudent(CreateStudentCommand createStudent)
        {
            var response = await _mediator.Send(createStudent);
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<StudentDetailsVm>> GetStudentDetails(int id)
        {
            var response = await _mediator.Send(new GetStudentDetailsQuery() { Id = id });
            return Ok(response);
        }
    }
}
