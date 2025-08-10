using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok();
        }
    }
}
