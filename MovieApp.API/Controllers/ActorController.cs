using Microsoft.AspNetCore.Mvc;
using MovieApp.API.DTOs;
using MovieApp.API.Services.Interfaces;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        // GET: api/actor
        [HttpGet]
        [ProducesResponseType(typeof(List<ActorReadDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ActorReadDto>>> GetAll()
        {
            var actors = await _actorService.GetAllAsync();
            return Ok(actors);
        }

        // GET: api/actor/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ActorReadDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ActorReadDto>> GetById(int id)
        {
            var actor = await _actorService.GetByIdAsync(id);
            if (actor == null) return NotFound();
            return Ok(actor);
        }

        // POST: api/actor
        [HttpPost]
        [ProducesResponseType(typeof(ActorReadDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ActorReadDto>> Create(ActorCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var createdActor = await _actorService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdActor.Id }, createdActor);
        }

        // PUT: api/actor/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Update(int id, ActorUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var updated = await _actorService.UpdateAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        // DELETE: api/actor/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _actorService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();

        }
    }
}
