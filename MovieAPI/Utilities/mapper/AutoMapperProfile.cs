using AutoMapper;
using MovieAPI.DTOs;
using MovieAPI.Entities;

namespace MovieAPI.Utilities.mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapGenres();
            MapActors();
            MapCines();
            MapMovies();
        }

        private void MapGenres()
        {
            CreateMap<GenreRequestDto, Genre>();
            CreateMap<Genre, GenreResponseDto>();
        }

        private void MapActors()
        {
            CreateMap<ActorRequestDto, Actor>()
                .ForMember((x) => x.Picture, (options) => options.Ignore());
            CreateMap<Actor, ActorResponseDto>();
        }

        private void MapCines()
        {

        }

        private void MapMovies()
        {

        }
    }
}
