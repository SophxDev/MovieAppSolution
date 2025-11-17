using AutoMapper;
using MovieApp.API.DTOs;
using MovieApp.API.Models;
using MovieApp.API.Repositories.Interfaces;
using MovieApp.API.Services.Interfaces;

namespace MovieApp.API.Services
{
    public class ActorService : IActorService
    {   
        private readonly IActorRepository _actorRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public ActorService(IMovieRepository movieRepository, IActorRepository actorRepository, IMapper mapper)
        { 
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
            _mapper = mapper;
        }

        //Listar actores
        public async Task<List<ActorReadDto>> GetAllAsync()
        {
            var actors = await _actorRepository.GetAllWithMoviesAsync();
            return _mapper.Map<List<ActorReadDto>>(actors);
        }

        // Traer actor por id
        public async Task<ActorReadDto?> GetByIdAsync(int id)
        {
            var actor = await _actorRepository.GetByIdWithMoviesAsync(id);
            return actor == null ? null : _mapper.Map<ActorReadDto>(actor);
        }

        // Crear actor
        public async Task<ActorReadDto>CreateAsync(ActorCreateDto dto)
        {
            var actor = _mapper.Map<Actor>(dto);
            var createdActor = await _actorRepository.CreateAsync(actor);
            return _mapper.Map<ActorReadDto>(createdActor);
        }

        //Actualizar actor
        public async Task<bool> UpdateAsync(int id, ActorUpdateDto dto)
        {
            // Verifica si el actor existe
            var existingActor = await _actorRepository.GetByIdAsync(id);
            if (existingActor is null) return false;

            // Mapea los datos nuevos sobre el actor existente
            _mapper.Map(dto, existingActor);

            // Actualiza en base de datos
            await _actorRepository.UpdateAsync(existingActor);

            return true;

        }
        //Eliminar actor
        public async Task<bool> DeleteAsync(int id)
        {
            var actor = await _actorRepository.GetByIdAsync(id);
            if (actor == null) return false;

            await _actorRepository.DeleteAsync(actor);
            return true;
        }

    }
}
