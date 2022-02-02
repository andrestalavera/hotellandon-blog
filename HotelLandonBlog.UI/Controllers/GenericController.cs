using HotelLandonBlog.Entities;
using HotelLandonBlog.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace HotelLandonBlog.UI.Controllers
{
    public abstract class GenericController<TRepository, TEntity> : Controller, IRazorController<TEntity>
        where TRepository : IRepository<TEntity>
        where TEntity : EntityBase


    {
        protected readonly IRepository<TEntity> repository;


        protected readonly ILogger<GenericController<TRepository, TEntity>> logger;


        public GenericController(IRepository<TEntity> repository,
            ILogger<GenericController<TRepository, TEntity>> logger)
        {
            this.repository = repository;
            this.logger = logger;

        }

        public async Task<ActionResult<IEnumerable<TEntity>>> Index(string search)
        {

            return View(await repository.GetAllAsync());
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<TEntity>> Create()
        {
            return View(default(TEntity));
        }

        [HttpPost("[action]/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<TEntity>> Create(int id, TEntity t)
        {

            if (id != t.Id)
            {
                return View("NotFound");
            }

            if (ModelState.IsValid)
            {
                return await repository.CreateAsync(t);
            }

            if (!ModelState.IsValid)
            {
                return View(t);
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            return View(repository.GetAsync(id));
        }
        [HttpPost("[action]/{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id, TEntity t)
        {
            if (id != t.Id)
            {
                return View("NotFound");
            }
            if (!ModelState.IsValid)
            {
                return View(t);
            }
            try
            {
                await repository.DeleteAsync(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<TEntity>> Details(int id)
        {
            TEntity entity = await repository.GetAsync(id);
            if (entity == null)
            {
                return View("NotFound");
            }
            return View(entity);
        }
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<TEntity>> Edit(int id)
        {
            if (id == null)
            {
                return View("NotFound");
            }
            TEntity entity = await repository.GetAsync(id);
            if (entity == null)
            {
                return View("NotFound");
            }
            return View(entity);
        }
        [HttpPost("[action]/{id}")]
        public async Task<ActionResult<TEntity>> Edit(int id, TEntity t)
        {
            if (id != t.Id)
            {
                return View("NotFound");
            }
            if (!ModelState.IsValid)
            {
                return View(t);
            }
            try
            {
                await repository.UpdateAsync(id, t);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<TEntity>> Undelete(int id)
        {
            return View(repository.GetAsync(id));
        }
        [HttpPost("[action]/{id}")]
        public async Task<ActionResult<TEntity>> Undelete(int id, TEntity t)
        {
            if (id != t.Id)
            {
                return View("NotFound");
            }
            if (!ModelState.IsValid)
            {
                return View(t);
            }
            try
            {
                await repository.DeleteAsync(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
