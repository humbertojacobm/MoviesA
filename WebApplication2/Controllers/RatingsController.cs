using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Services;

namespace Movies.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingsController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet("by-movie/{movieId}")]
        public async Task<IActionResult> GetRatingsByMovieId(int movieId)
        {
            var ratings = await _ratingService.GetRatingsByMovieIdAsync(movieId);
            return Ok(ratings);
        }
    }
}
