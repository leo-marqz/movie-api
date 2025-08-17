using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using MovieAPI.DTOs;
using MovieAPI.Entities;
using MovieAPI.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private const string CaheTag = "genres";
        private readonly IOutputCacheStore _outputCacheStore;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenresController(
            IOutputCacheStore outputCacheStore, 
            ApplicationDbContext context,
            IMapper mapper)
        {
            this._outputCacheStore = outputCacheStore;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [OutputCache(Tags = [CaheTag])]
        public async Task<ActionResult<List<GenreResponseDto>>> GetAllAsync(
            [FromQuery] PaginationDto pagination)
        {
            var queryable = this.context.Genres;
            await HttpContext.InsertPaginationParametersInTheHeaders(queryable);
            return await queryable
                .OrderBy((x)=>x.Name) //necesario para no tener datos a lo bestia.
                .Paginate(pagination)
                .ProjectTo<GenreResponseDto>(this.mapper.ConfigurationProvider)
                .ToListAsync();
        }

        [HttpGet("{id:int}", Name = "GetGenreById")]
        [OutputCache(Tags = [CaheTag])]
        public async Task<ActionResult<GenreResponseDto>> GetByIdAsync(int id)
        {
            var dto = await this.context.Genres
                .ProjectTo<GenreResponseDto>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync((x)=>x.Id == id);
            
            if(dto is null)
            {
                return NotFound($"Genero con id {id} no encontrado!");
            }

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync( [FromBody] GenreRequestDto request)
        {
            if(request == null)
            {
                return NotFound();
            }

            var genre = this.mapper.Map<Genre>(request);

            this.context.Add(genre);
            await this.context.SaveChangesAsync();

            //tag: genres - refresca la cache
            await _outputCacheStore.EvictByTagAsync(CaheTag, default);

            return CreatedAtRoute("GetGenreById", new {id = genre.Id}, genre);
        }
    }
}
