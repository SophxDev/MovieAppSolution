using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieApp.API.Data;
using MovieApp.API.DTOs;
using MovieApp.API.Models;
using MovieApp.API.Repositories.Interfaces;
using MovieApp.API.Services.Interfaces;

namespace MovieApp.API.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;
        
        public MovieService(IMovieRepository movieRepository, IActorRepository actorRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
            _mapper = mapper;
            
        }

        // Listar peliculas
        public async Task<List<MovieReadDto>> GetAllAsync()
        {
            var movies = await _movieRepository.GetAllAsync();
            return _mapper.Map<List<MovieReadDto>>(movies);
        }

        // Traer pelicula por el id
        public async Task<MovieReadDto?> GetByIdAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            return movie == null ? null : _mapper.Map<MovieReadDto>(movie);
        }

        // Crear pelicula
        public async Task<MovieReadDto> CreateAsync(MovieCreateDto dto)
        {
            var movie = _mapper.Map<Movie>(dto);

            //Obtener actores por ID
            var actors = await _actorRepository.GetByIdsAsync(dto.ActorIds);

            foreach (var actor in actors)
            {
                movie.MovieActors.Add(new MovieActor
                {
                    ActorId = actor.Id,
                });
            }

            var createdMovie = await _movieRepository.CreateAsync(movie);
            return _mapper.Map<MovieReadDto>(createdMovie);
                
        }

        // Actualizar pelicula y actores pertenecientes.
        public async Task<bool> UpdateAsync(int id, MovieUpdateDto dto)
        {
            var movie = await _movieRepository.GetByIdWithActorsAsync(id);
            if (movie is null) return false;

            //Mapear propiedades básicas desde el DTO al modelo existente
            _mapper.Map(dto, movie);

            //Actualizar manualmente los acroes (relacion uno a uno)
            movie.MovieActors.Clear();

            var newActors = await _actorRepository.GetByIdsAsync(dto.ActorIds);

            foreach (var actor in newActors)
            {
                movie.MovieActors.Add(new MovieActor
                {
                    ActorId = actor.Id
                });
            }

            await _movieRepository.UpdateAsync(movie);
            return true;
        }

        //Eliminar pelicula
        public async Task<bool> DeleteAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null) return false;

            await _movieRepository.DeleteAsync(movie);
            return true;
        }
        

        //PELICULAS / ACTORES
       
        // Lista de peliculas + actores
        public async Task<List<MovieReadDto>> GetAllWithActorsAsync()
        {
            var movies = await _movieRepository.GetAllWithActorsAsync();
            return _mapper.Map<List<MovieReadDto>>(movies);
        }

        // Retorna pelicula + actores que coincidan con el id(pelicula)
        public async Task<MovieReadDto?> GetByIdWithActorsAsync(int id)
        {
            var movie = await _movieRepository.GetByIdWithActorsAsync(id);
            return movie is null ? null : _mapper.Map<MovieReadDto>(movie);
        }
        
    }
}
