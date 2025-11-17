using AutoMapper;
using MovieApp.API.DTOs;
using MovieApp.API.Models;

namespace MovieApp.API.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MovieCreateDto, Movie>();
            CreateMap<MovieUpdateDto, Movie>();

            CreateMap<Movie, MovieReadDto>()
                .ForMember(dest => dest.Actors,
                    opt => opt.MapFrom(src =>
                        src.MovieActors.Select(ma => ma.Actor.Name).ToList()
                    ));

            // Actor
            //Remplazo del mapeo automatico, indica a Automapper como llenar MovieIds
            CreateMap<Actor, ActorReadDto>()
                .ForMember(dest => dest.MovieIds,
                opt => opt.MapFrom(src => src.MovieActors.Select(ma => ma.MovieId).ToList()));

            CreateMap<ActorCreateDto, Actor>();
            CreateMap<ActorUpdateDto, Actor>().ReverseMap();
        }
    }
}
