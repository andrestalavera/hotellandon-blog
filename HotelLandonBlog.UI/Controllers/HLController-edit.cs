using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HotelLandonBlog.Repository;
using HotelLandonBlog.Entities;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace HotelLandonBlog.UI.Controllers
{
    public partial class HLController<TRepository, TEntity> : Controller

       where TRepository : IRepository<TEntity>
       where TEntity : EntityBase
    {


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
                if (await this.repository.UpdateAsync(entity, id))
                {
                    return RedirectToAction();
                }
            }
            return View(entity);
            // Create
            // Update
        }
    }
}

    
