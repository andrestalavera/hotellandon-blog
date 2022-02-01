using HotelLandonBlog.Entities;
using HotelLandonBlog.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLandonBlog.UI.Controllers
{
    public class GenericController<TRepository, TEntity> : Controller
         where TRepository : IRepository<TEntity>
         where TEntity : EntityBase
    {
        protected readonly IRepository<TEntity> repository;
        protected readonly ILogger<GenericController<TRepository, TEntity>> logger;

        public virtual async Task<IActionResult> Edit(int? id)
      {
           if (id is null)
           {
                return null; //View("NotFound");
           }
           var entity = await this.repository.GetAsync(id.Value);
                
           if (entity == null)
           {
                return null; //View("NotFound");
           }
                return null; //View(entity);
       }
        
            [HttpPost("[action]/{id?}")]

            [ValidateAntiForgeryToken]

        public virtual async Task<IActionResult> Edit([Bind("Id")] TEntity entity, int id)
        {
            if (!entity.Id.Equals(id))
            {
                return null; //View("NotFound");
            }
            if (ModelState.IsValid)
            {
                if (await this.repository.UpdateAsync(id, entity))
                {
                    return RedirectToAction();
                }
            }
            return View(entity);
            // Create
            // Update
        }
        /*public IActionResult Index()
        {
            return View();
        }*/

    }
}
}
