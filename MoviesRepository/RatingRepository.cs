using Movies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Movies.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ApplicationDbContext _context;

        public RatingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rating>> GetRatingsByMovieIdAsync(int movieId)
        {
            return await _context.Ratings
                                 .Where(r => r.MovieId == movieId)
                                 .ToListAsync();
        }
    }
}
