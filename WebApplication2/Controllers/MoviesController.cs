using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Services;
using DTO = Movies.DTOs;

namespace Movies.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpGet("by-actor/{actorId}")]
        public async Task<IActionResult> GetMoviesByActorId(int actorId)
        {
            var movies = await _movieService.GetMoviesByActorIdAsync(actorId);
            return Ok(movies);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] DTO.Movie movieDto)
        {
            await _movieService.AddMovieAsync(movieDto);
            return CreatedAtAction(nameof(GetMovieById), new { id = movieDto.ReleaseYear }, movieDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] DTO.Movie movieDto)
        {
            await _movieService.UpdateMovieAsync(id, movieDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _movieService.DeleteMovieAsync(id);
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchMoviesByPartialName([FromQuery] string partialName)
        {
            var movies = await _movieService.SearchMoviesByPartialNameAsync(partialName);
            return Ok(movies);
        }
    }
}
