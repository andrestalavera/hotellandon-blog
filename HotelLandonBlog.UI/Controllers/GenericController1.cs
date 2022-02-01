using HotelLandonBlog.Entities;
using HotelLandonBlog.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HotelLandonBlog.UI.Controllers
{
    public abstract class GenericController<TRepository, TEntity> : Controller
        where TRepository : IRepository<TEntity>
        where TEntity : EntityBase
    {
        protected readonly IRepository<TEntity> repository;
        protected readonly ILogger<GenericController<TRepository, TEntity>> logger;

        [HttpGet("[action]")]
        public virtual IActionResult Create() => View(default(TEntity));

        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult<TEntity>> Create([Bind("Id")] TEntity entity)
        {
            if (ModelState.IsValid)
            {
                if (await this.repository.CreateAsync(entity))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(entity);
        }
    }
}
