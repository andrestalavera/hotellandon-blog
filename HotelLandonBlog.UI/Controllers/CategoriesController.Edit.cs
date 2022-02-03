using HotelLandonBlog.Entities;
using HotelLandonBlog.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HotelLandonBlog.UI.Controllers
{
    public partial class CategoriesController : GenericController<IRepository<Category>, Category>, IRazorController<Category>
    {
        // Get
        public override Task<ActionResult<Category>> IRazorController<Category>.Edit(int id)
        {
            if (!entity.Id.Equals(id))
            {
                return View("NotFound");
            }

            return RedirectToAction("Edit");

        }

        [HttpPost("[action]/{id?}")]
        public override Task<ActionResult<Category>> IRazorController<Category>.Edit([Bind(new[] {
           nameof(Category.Name),})] Category entity, int id) => base.Edit(id, entity);

       
    }
}
