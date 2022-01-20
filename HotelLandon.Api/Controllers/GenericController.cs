using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using HotelLandon.Models;
using HotelLandon.Repository;

namespace HotelLandon.Api.Controllers
{
    [ApiController, Route("[controller]")]
    public abstract class GenericController<TRepository, TEntity> : ControllerBase
        where TRepository : IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        private readonly IRepositoryBase<TEntity> repository;
        private readonly ILogger<GenericController<TRepository, TEntity>> logger;

        public GenericController(IRepositoryBase<TEntity> repository,
            ILogger<GenericController<TRepository, TEntity>> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<TEntity> Get()
        {
            IEnumerable<TEntity> items = this.repository.GetAll();
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<TEntity> GetById(int id)
        {
            TEntity entity = this.repository.Get(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public ActionResult<TEntity> Create(TEntity entity)
        {
            if (this.repository.Add(entity))
            {
                return Created("Ok", entity);
            }
            return NoContent();
        }

        [HttpPut]
        public IActionResult Update(TEntity entity, int id)
        {
            if (!entity.Id.Equals(id))
            {
                return BadRequest("Les ids ne correspondent pas");
            }
            if (this.repository.Update(entity, id))
            {
                return NoContent();
            }
            return StatusCode(406);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (this.repository.Delete(id))
            {
                return NoContent();
            }
            return Ok(true);
        }
    }
}
