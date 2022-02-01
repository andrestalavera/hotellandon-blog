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
        protected readonly IRepository<TEntity> repository;
        protected readonly ILogger<HLController<TRepository, TEntity>> logger;



        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return null;
            }
            TEntity entity = await this.repository.GetAsync(id.Value);
            if (entity is null)
            {
                return null; //View("NotFound");
            }
            return null; //View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCompleted(int id)
        {
            if (await this.repository.DeleteAsync(id))
            {
                return null; //View(true);
            }
            return null; //View(false);
        }
    }
}