using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using MovieAPI.DTOs;
using MovieAPI.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private const string CACHE_TAG = "actors";

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IOutputCacheStore cacheStore;

        public ActorsController(
            ApplicationDbContext context,
            IMapper mapper, IOutputCacheStore cacheStore)
        {
            this.context = context;
            this.mapper = mapper;
            this.cacheStore = cacheStore;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorResponseDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id:int}", Name = "GetActorById")]
        public async Task<ActionResult<ActorResponseDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromForm] ActorRequestDto request)
        {
            var actor = this.mapper.Map<Actor>(request);

            //!PENDING: Process Picture

            this.context.Add(actor);

            await this.context.SaveChangesAsync();
            await this.cacheStore.EvictByTagAsync(CACHE_TAG, default);

            return CreatedAtRoute("GetActorById", new { id = actor.Id }, actor);
        }
    }
}
