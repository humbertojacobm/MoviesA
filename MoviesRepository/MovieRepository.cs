using Microsoft.EntityFrameworkCore;
using Movies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetMoviesByActorIdAsync(int actorId)
        {
            return await _context.Movies
                                 .Where(m => m.Actors.Any(a => a.Id == actorId))
                                 .ToListAsync();
        }
        public async Task<IEnumerable<Movie>> SearchMoviesByPartialNameAsync(string partialName)
        {
            return await _context.Movies
                                 .Where(m => m.Title.Contains(partialName))
                                 .ToListAsync();
        }
    }
}
