using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO = Movies.DTOs;
using Model = Movies.Model;
using AutoMapper;
using Movies.Repository;

namespace Movies.Services
{
    public class ActorService : IActorService
    {
        private readonly IRepository<Model.Actor> _repository;
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;

        public ActorService(
            IRepository<Model.Actor> repository,
             IActorRepository actorRepository,
            IMapper mapper)
        {
            _repository = repository;
            _actorRepository = actorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DTO.Actor>> GetAllActorsAsync()
        {
            var actors = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DTO.Actor>>(actors);
        }

        public async Task<DTO.Actor> GetActorByIdAsync(int id)
        {
            var actor = await _repository.GetByIdAsync(id);
            return _mapper.Map<DTO.Actor>(actor);
        }

        public async Task AddActorAsync(DTO.Actor actorDto)
        {
            var actor = _mapper.Map<Model.Actor>(actorDto);
            await _repository.AddAsync(actor);
        }

        public async Task UpdateActorAsync(int id, DTO.Actor actorDto)
        {
            var existingActor = await _repository.GetByIdAsync(id);
            if (existingActor != null)
            {
                _mapper.Map(actorDto, existingActor);
                await _repository.UpdateAsync(existingActor);
            }
        }

        public async Task DeleteActorAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<DTO.Actor>> GetActorsByMovieIdAsync(int movieId)
        {
            var actors = await _actorRepository.GetActorsByMovieIdAsync(movieId);
            return _mapper.Map<IEnumerable<DTO.Actor>>(actors);
        }
    }
}
