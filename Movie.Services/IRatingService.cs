using Movies.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services
{
    public interface IRatingService
    {
        Task<IEnumerable<RatingDTO>> GetRatingsByMovieIdAsync(int movieId);
    }
}
