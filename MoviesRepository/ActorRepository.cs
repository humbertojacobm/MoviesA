using Microsoft.EntityFrameworkCore;
using Movies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Repository
{
    public class ActorRepository : IActorRepository
    {
        private readonly ApplicationDbContext _context;

        public ActorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Actor>> GetActorsByMovieIdAsync(int movieId)
        {
            return await _context.Actors
                                 .Where(a => a.Movies.Any(m => m.Id == movieId))
                                 .ToListAsync();
        }
    }
}
