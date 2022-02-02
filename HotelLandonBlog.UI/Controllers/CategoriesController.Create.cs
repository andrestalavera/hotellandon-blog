using HotelLandonBlog.Entities;
using HotelLandonBlog.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HotelLandonBlog.UI.Controllers
{
    public partial class CategoriesController : GenericController<IRepository<Category>, BlogPost>, IRazorController<Category>
    {
        // Get
        [HttpGet]
        public override Task<ActionResult<Category>> Create()
        {
            return View(default(Category));
        }
        // Post
        [HttpPost("[action]/{id}")]
        public override Task<ActionResult<Category>> Create([Bind(new[] {
            nameof(Category.Name),
            })] Category entity, int id) => base.Create(entity, id);
    }
}
