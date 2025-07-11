using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeknorixTest.Commands;
using TeknorixTest.Models;
using TeknorixTest.Queries;

namespace TeknorixTest.Controllers
{
    [ApiController]
    
    public class LocationController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [Route("api/v1/Locations")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateLocationDto model)
        {
            var locationId = await _mediator.Send(new CreateLocationCommand { Location = model });
            return CreatedAtAction(nameof(Create) ,new { Id = locationId });
        }
       
        [HttpPut]
        [Route("api/v1/Locations/{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] CreateLocationDto model)
        {
            var result = await _mediator.Send(new UpdateLocationCommand
            {
                Id = id,
                Locationdto = model
            });

            if (!result)
                return NotFound(new { Message = "Location not found." });

            return Ok(new { Message = "Location updated successfully." });
        }

        [HttpGet]
        [Route("api/v1/Locations")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var locations = await _mediator.Send(new GetAllLocationQuery());
            return Ok(locations);
        }


    }
}
