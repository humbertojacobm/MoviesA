//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DTO = Movies.DTOs;
//using Model = Movies.Model;
//using AutoMapper;

//namespace Movies.Services
//{
//    public class ActorService : IActorService
//    {
//        private readonly IRepository<Model.Actor> _repository;
//        private readonly IMapper _mapper;

//        public ActorService(IRepository<Actor> repository, IMapper mapper)
//        {
//            _repository = repository;
//            _mapper = mapper;
//        }

//        public async Task<IEnumerable<ActorDTO>> GetAllActorsAsync()
//        {
//            var actors = await _repository.GetAllAsync();
//            return _mapper.Map<IEnumerable<ActorDTO>>(actors);
//        }

//        public async Task<ActorDTO> GetActorByIdAsync(int id)
//        {
//            var actor = await _repository.GetByIdAsync(id);
//            return _mapper.Map<ActorDTO>(actor);
//        }

//        public async Task AddActorAsync(ActorDTO actorDto)
//        {
//            var actor = _mapper.Map<Actor>(actorDto);
//            await _repository.AddAsync(actor);
//        }

//        public async Task UpdateActorAsync(int id, ActorDTO actorDto)
//        {
//            var existingActor = await _repository.GetByIdAsync(id);
//            if (existingActor != null)
//            {
//                _mapper.Map(actorDto, existingActor);
//                await _repository.UpdateAsync(existingActor);
//            }
//        }

//        public async Task DeleteActorAsync(int id)
//        {
//            await _repository.DeleteAsync(id);
//        }
//    }
//}
