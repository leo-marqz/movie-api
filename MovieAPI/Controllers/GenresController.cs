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
        public GenresController()
        {
            
        }

        [HttpGet]
        [OutputCache]
        public async Task<ActionResult<List<Genre>>> GetAllAsync()
        {
            await Task.Delay(3000);
            return Ok(new InMemoryRepository().getAll());
        }

        [HttpPost]
        public async Task<ActionResult> Post( [FromBody] Genre genre)
        {
            var repository = new InMemoryRepository();

            var genreExists = repository.Exists(genre.Name);

            if (genreExists)
            {
                return BadRequest($"El genero con nombre {genre.Name} ya existe!");
            }

            return Ok(new
            {
                statusCode = 200,
                message = "Genero agregado exitosamente!",
                data = genre
            });
        }
    }
}
