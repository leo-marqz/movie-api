using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using MovieAPI.Entities;
using MovieAPI.Repositories;

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
    }
}
