using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Services;

namespace Movies.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActors()
        {
            var actors = await _actorService.GetAllActorsAsync();
            return Ok(actors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActorById(int id)
        {
            var actor = await _actorService.GetActorByIdAsync(id);
            if (actor == null)
            {
                return NotFound();
            }
            return Ok(actor);
        }

        [HttpPost]
        public async Task<IActionResult> AddActor([FromBody] DTOs.Actor actorDto)
        {
            await _actorService.AddActorAsync(actorDto);
            return CreatedAtAction(nameof(GetActorById), new { id = actorDto.Name }, actorDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActor(int id, [FromBody] DTOs.Actor actorDto)
        {
            await _actorService.UpdateActorAsync(id, actorDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            await _actorService.DeleteActorAsync(id);
            return NoContent();
        }
    }
}
