using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeknorixTest.Commands;
using TeknorixTest.Dtos;
using TeknorixTest.Queries;

namespace TeknorixTest.Controllers
{
    [ApiController]
    
    public class DepartmentController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [Route("api/v1/Departments")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateDepartmentDto model)
        {
            var jobId = await _mediator.Send(new CreateDepartmentCommand { Department = model });
            return CreatedAtAction(nameof(Create),new { Id = jobId });
        }
      
        [HttpPost]
        [Route("api/v1/Departments/{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] CreateDepartmentDto model)
        {
            var result = await _mediator.Send(new UpdateDepartmentCommand
            {
                Id = id,
                Department = model
            });

            if (!result)
                return NotFound(new { Message = "Department not found." });

            return Ok(new { Message = "Department updated successfully." });
        }

        [HttpGet]
        [Route("api/v1/Departments")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllDepartmentQuery());
            return Ok(result);
        }

    }
}
