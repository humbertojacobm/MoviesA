using Movies.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAllActorsAsync();
        Task<Actor> GetActorByIdAsync(int id);
        Task AddActorAsync(Actor actorDto);
        Task UpdateActorAsync(int id, Actor actorDto);
        Task DeleteActorAsync(int id);
        Task<IEnumerable<Actor>> GetActorsByMovieIdAsync(int movieId);
    }
}
