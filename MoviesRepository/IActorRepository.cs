using Movies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Repository
{
    public interface IActorRepository
    {
        Task<IEnumerable<Actor>> GetActorsByMovieIdAsync(int movieId);
    }
}
