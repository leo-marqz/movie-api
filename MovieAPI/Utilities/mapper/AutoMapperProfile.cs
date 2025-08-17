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

        }

        private void MapCines()
        {

        }

        private void MapMovies()
        {

        }
    }
}
