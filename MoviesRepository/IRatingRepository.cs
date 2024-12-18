using Movies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Repository
{
    public interface IRatingRepository
    {
        Task<IEnumerable<Rating>> GetRatingsByMovieIdAsync(int movieId);
    }
}
