using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO = Movies.DTOs;

namespace Movies.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<DTO.Movie>> GetAllMoviesAsync();
        Task<DTO.Movie> GetMovieByIdAsync(int id);
        Task AddMovieAsync(DTO.Movie movieDto);
        Task UpdateMovieAsync(int id, DTO.Movie movieDto);
        Task DeleteMovieAsync(int id);
        Task<IEnumerable<DTO.Movie>> GetMoviesByActorIdAsync(int actorId);
        Task<IEnumerable<DTO.Movie>> SearchMoviesByPartialNameAsync(string partialName);
    }
}
