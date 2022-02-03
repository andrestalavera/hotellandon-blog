﻿using HotelLandonBlog.Entities;
using HotelLandonBlog.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HotelLandonBlog.UI.Controllers
{
    public abstract class GenericController<TRepository, TEntity> : Controller, IRazorController<TEntity>
        where TRepository : IRepository<TEntity>
        where TEntity : EntityBase, new()
    {
        protected readonly IRepository<TEntity> repository;
        protected readonly ILogger<GenericController<TRepository, TEntity>> logger;

        public GenericController(IRepository<TEntity> repository,
            ILogger<GenericController<TRepository, TEntity>> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public virtual async Task<IActionResult> Index(string search)
        {
            return View(await repository.GetAllAsync());
        }

        [HttpGet("[action]")]
        public virtual async Task<IActionResult> Create()
        {
            return View(new TEntity());
        }

        [HttpPost("[action]/{id}")]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(TEntity t)
        {
            if (ModelState.IsValid)
            {
                await repository.CreateAsync(t);
                return RedirectToAction(nameof(Index));
            }

            return await Create();
        }

        [HttpGet("[action]/{id}")]
        public virtual async Task<IActionResult> Delete(BlogPost entity, int id)
        {
            return View(repository.GetAsync(id));
        }

        [HttpPost("[action]/{id}")]
        public virtual async Task<IActionResult> Delete(int id, TEntity t)
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
        public virtual async Task<IActionResult> Details(int id)
        {
            TEntity entity = await repository.GetAsync(id);
            if (entity == null)
            {
                return View("NotFound");
            }
            return View(entity);
        }

        [HttpGet("[action]/{id}")]
        public virtual async Task<IActionResult> Edit(int id)
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
        public virtual async Task<IActionResult> Edit(int id, TEntity t)
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
        public virtual async Task<IActionResult> Undelete(int id)
        {
            return View(repository.GetAsync(id));
        }

        [HttpPost("[action]/{id}")]
        public virtual async Task<IActionResult> Undelete(int id, TEntity t)
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