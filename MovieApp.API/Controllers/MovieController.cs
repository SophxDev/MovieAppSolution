using Microsoft.AspNetCore.Mvc;
using MovieApp.API.DTOs;
using MovieApp.API.Services.Interfaces;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/movie
        [HttpGet]
        [ProducesResponseType(typeof(List<MovieReadDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<MovieReadDto>>> GetAll()
        {
            var movies = await _movieService.GetAllAsync();
            return Ok(movies);
        }

        //GET: api/movie/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MovieReadDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieReadDto>> GetById(int id)
        {
            var movie = await _movieService.GetByIdAsync(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        // POST: api/movie
        [HttpPost]
        [ProducesResponseType(typeof(MovieReadDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MovieReadDto>> Create(MovieCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createMovie = await _movieService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createMovie.Id }, createMovie);

        }

        // PUT: api/movie/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Update(int id, MovieUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _movieService.UpdateAsync(id, dto);
            if (!result) return NotFound();
            return NoContent();
        }

        // DELETE: api/movie/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _movieService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

    }
}
