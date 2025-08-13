using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Entities;
using System.Collections.Generic;
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

        public GenresController(IOutputCacheStore outputCacheStore, ApplicationDbContext context)
        {
            this._outputCacheStore = outputCacheStore;
            this.context = context;
        }

        [HttpGet]
        [OutputCache(Tags = [CaheTag] )]
        public async Task<ActionResult<List<Genre>>> GetAllAsync()
        {
            await Task.Delay(3000);
            var genres = await this.context.Genres.ToListAsync();
            
            //new List<Genre>()
            //{
            //    new Genre {Id=1, Name="Action"},
            //    new Genre {Id=2, Name="Comedy"},
            //    new Genre {Id=3, Name="Drama"},
            //    new Genre {Id=4, Name="Horror"},
            //    new Genre {Id=5, Name="Romance"},
            //    new Genre {Id=6, Name="Thriller"}
            //};

            return Ok(genres);
        }

        [HttpGet("{id:int}", Name = "GetGenreById")]
        [OutputCache(Tags = [CaheTag])]
        public async Task<ActionResult<Genre>> GetById(int id)
        {
            await Task.Delay(10);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Post( [FromBody] Genre genre)
        {
            if(genre == null)
            {
                return NotFound();
            }

            this.context.Add(genre);
            await this.context.SaveChangesAsync();

            //tag: genres - refresca la cache
            await _outputCacheStore.EvictByTagAsync(CaheTag, default);

            return CreatedAtRoute("GetGenreById", new {id = genre.Id}, genre);
        }
    }
}
