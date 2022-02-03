using HotelLandonBlog.Entities;
using HotelLandonBlog.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HotelLandonBlog.UI.Controllers
{
    public partial class CategoriesController : GenericController<IRepository<Category>, Category>, IRazorController<Category>
    {


        // Post
        [HttpPost("[action]/{id}")]
        public override Task<IActionResult> Delete([Bind(new[] {
            nameof(Category.Name)
            })] Category entity) => base.Delete(entity);
    }
}