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
        private readonly IInMemoryRepository _repository;

        public GenresController(IOutputCacheStore outputCacheStore, IInMemoryRepository repository)
        {
            this._outputCacheStore = outputCacheStore;
            this._repository = repository;
        }

        [HttpGet]
        [OutputCache(Tags = [CaheTag] )]
        public async Task<ActionResult<List<Genre>>> GetAllAsync()
        {
            await Task.Delay(3000);
            return Ok(_repository.getAll());
        }

        [HttpGet("{id:int}")]
        [OutputCache(Tags = [CaheTag])]
        public async Task<ActionResult<Genre>> GetById(int id)
        {
            await Task.Delay(10);
            return Ok(_repository.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post( [FromBody] Genre genre)
        {
            var genreExists = _repository.Exists(genre.Name);

            if (genreExists)
            {
                return BadRequest($"El genero con nombre {genre.Name} ya existe!");
            }

            _repository.Create(genre);

            //tag: genres - refresca la cache
            await _outputCacheStore.EvictByTagAsync(CaheTag, default);

            return Ok(new
            {
                statusCode = 200,
                message = "Genero agregado exitosamente!",
                data = genre
            });
        }
    }
}
