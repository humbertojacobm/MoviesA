﻿using MoviesRepository;
using Model = MoviesEntities;
using DTO = Movies.DTOs;
using AutoMapper;

namespace Movie.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Model.Movie> _repository;
        private readonly IMapper _mapper;

        public MovieService(IRepository<Model.Movie> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DTO.Movie>> GetAllMoviesAsync()
        {
            var movies = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DTO.Movie>>(movies);
        }

        public async Task<DTO.Movie> GetMovieByIdAsync(int id)
        {
            var movie = await _repository.GetByIdAsync(id);
            return _mapper.Map<DTO.Movie>(movie);
        }

        public async Task AddMovieAsync(DTO.Movie movieDto)
        {
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
    }
}
