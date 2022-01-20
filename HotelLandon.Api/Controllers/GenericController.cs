using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using HotelLandon.Models;
using HotelLandon.Repository;
using System.Diagnostics;

namespace HotelLandon.Api.Controllers
{
    [ApiController, Route("[controller]")]
    public abstract class GenericController<TRepository, TEntity> : ControllerBase
        where TRepository : IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        protected readonly IRepositoryBase<TEntity> repository;
        protected readonly ILogger<GenericController<TRepository, TEntity>> logger;

        public GenericController(IRepositoryBase<TEntity> repository,
            ILogger<GenericController<TRepository, TEntity>> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<TEntity>> Get()
        {
            await Task.Delay(0);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            IEnumerable<TEntity> items = await this.repository.GetAllAsync();
            logger.LogInformation("{ms}ms", sw.ElapsedMilliseconds);
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> GetById(int id)
        {
            TEntity entity = await this.repository.GetAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<TEntity>> Create(TEntity entity)
        {
            if (await this.repository.AddAsync(entity))
            {
                return Created("Ok", entity);
            }
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(TEntity entity, int id)
        {
            if (!entity.Id.Equals(id))
            {
                return BadRequest("Les ids ne correspondent pas");
            }
            if (await this.repository.UpdateAsync(entity, id))
            {
                return NoContent();
            }
            return StatusCode(406);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (await this.repository.DeleteAsync(id))
            {
                return NoContent();
            }
            return Ok(true);
        }
    }
}
