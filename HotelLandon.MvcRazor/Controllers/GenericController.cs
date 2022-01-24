using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HotelLandon.Repository;
using HotelLandon.Models;

namespace HotelLandon.MvcRazor.Controllers
{
    public abstract class GenericController<TRepository, TEntity> : Controller
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

        public async Task<IActionResult> Index()
        {
            Stopwatch sw = new();
            sw.Start();
            IEnumerable<TEntity> items = await this.repository.GetAllAsync();
            logger.LogInformation("{ms}ms", sw.ElapsedMilliseconds);
            return View(items);
        }

        // .com/customers/details/id
        [HttpGet("[action]/{id}")]
        public virtual async Task<IActionResult> Details(int id)
        {
            TEntity entity = await this.repository.GetAsync(id);
            if (entity == null)
            {
                return View("NotFound");
            }
            return View(entity);
        }

        [HttpGet("[action]")]
        public virtual IActionResult Create() => View(default(TEntity));

        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult<TEntity>> Create([Bind("Id")] TEntity entity)
        {
            if (ModelState.IsValid)
            {
                if (await this.repository.AddAsync(entity))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(entity);
        }

        [HttpGet("[action]/{id?}")]
        public virtual async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return View("NotFound");
            }
            var entity = await this.repository.GetAsync(id.Value);
            if (entity == null)
            {
                return View("NotFound");
            }
            return View(entity);
        }

        [HttpPost("[action]/{id?}")]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit([Bind("Id")] TEntity entity, int id)
        {
            if (!entity.Id.Equals(id))
            {
                return View("NotFound");
            }
            if (ModelState.IsValid)
            {
                if (await this.repository.UpdateAsync(entity, id))
                {
                    return RedirectToAction(nameof(Details), new { id });
                }
            }
            return View(entity);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return View("NotFound");
            }
            TEntity entity = await this.repository.GetAsync(id.Value);
            if (entity is null)
            {
                return View("NotFound");
            }
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCompleted(int id)
        {
            if (await this.repository.DeleteAsync(id))
            {
                return View(true);
            }
            return View(false);
        }
    }
}
