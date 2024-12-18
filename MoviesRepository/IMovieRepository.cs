using Movies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Repository
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMoviesByActorIdAsync(int actorId);
        Task<IEnumerable<Movie>> SearchMoviesByPartialNameAsync(string partialName);
    }
}
