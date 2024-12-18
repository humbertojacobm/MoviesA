using Movies.Repository;
using Model = Movies.Model;
using DTO = Movies.DTOs;
using AutoMapper;

namespace Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Model.Movie> _repository;
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(
            IRepository<Model.Movie> repository,
            IMovieRepository movieRepository,
            IMapper mapper)
        {
            _repository = repository;
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DTO.Movie>> GetAllMoviesAsync()
        {
            var movies = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DTO.Movie>>(movies);
        }

        public async Task<DTO.Movie> GetMovieByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid movie ID.");

            var movie = await _repository.GetByIdAsync(id);
            if (movie == null)
                throw new KeyNotFoundException("Movie not found.");

            return _mapper.Map<DTO.Movie>(movie);
        }

        public async Task AddMovieAsync(DTO.Movie movieDto)
        {
            if (string.IsNullOrWhiteSpace(movieDto.Name))
                throw new ArgumentException("Movie title cannot be empty.");

            var movie = _mapper.Map<Model.Movie>(movieDto);
            await _repository.AddAsync(movie);
        }

        public async Task UpdateMovieAsync(int id, DTO.Movie movieDto)
        {
            var existingMovie = await _repository.GetByIdAsync(id);
            if (existingMovie != null)
            {
                _mapper.Map(movieDto, existingMovie);
                await _repository.UpdateAsync(existingMovie);
            }
        }

        public async Task DeleteMovieAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<DTO.Movie>> GetMoviesByActorIdAsync(int actorId)
        {
            var movies = await _movieRepository.GetMoviesByActorIdAsync(actorId);
            return _mapper.Map<IEnumerable<DTO.Movie>>(movies);
        }
        public async Task<IEnumerable<DTO.Movie>> SearchMoviesByPartialNameAsync(string partialName)
        {
            var movies = await _movieRepository.SearchMoviesByPartialNameAsync(partialName);
            return _mapper.Map<IEnumerable<DTO.Movie>>(movies);
        }
    }
}
