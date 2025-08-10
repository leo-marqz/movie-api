using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using MovieAPI.Entities;
using MovieAPI.Repositories;
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

        public GenresController(IOutputCacheStore outputCacheStore, IInMemoryRepository repository)
        {
            this._outputCacheStore = outputCacheStore;
        }

        [HttpGet]
        [OutputCache(Tags = [CaheTag] )]
        public async Task<ActionResult<List<Genre>>> GetAllAsync()
        {
            await Task.Delay(3000);
            return Ok();
        }

        [HttpGet("{id:int}")]
        [OutputCache(Tags = [CaheTag])]
        public async Task<ActionResult<Genre>> GetById(int id)
        {
            await Task.Delay(10);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Post( [FromBody] Genre genre)
        {
            //tag: genres - refresca la cache
            await _outputCacheStore.EvictByTagAsync(CaheTag, default);

            return Ok(new
            {
                statusCode = 200,
                message = "Genero agregado exitosamente!",
                data = new { }
            });
        }
    }
}
