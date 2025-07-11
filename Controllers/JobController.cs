using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TeknorixTest.Commands;
using TeknorixTest.Dtos;
using TeknorixTest.Queries;

namespace TeknorixTest.Controllers
{
    [ApiController]
    
    public class JobController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [Route("api/v1/jobs")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateJobDto model)
        {
            var jobId = await _mediator.Send(new CreateJobCommand { CreateJobDto = model });
            return CreatedAtAction(nameof(Create),new { Id = jobId });
        }
        

        [HttpPut]
        [Route("api/v1/jobs/{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] CreateJobDto model)
        {
            var result = await _mediator.Send(new UpdateJobCommand
            {
                Id = id,
                CreateJobDto = model
            });

            if (!result)
                return NotFound(new { Message = "Job not found." });

            return Ok(new { Message = "Job updated successfully." });
        }

        [HttpGet]
        [Route("api/v1/Jobs/{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetJobByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpPost]
        [Route("api/Jobs/List")]
        [Authorize]
        public async Task<IActionResult> FilterJobs([FromBody] JobFilterDto filter)
        {
            var result = await _mediator.Send(new GetFilteredJobsQuery { Filter = filter });
            return Ok(result);
        }

    }
}
