using HotelLandonBlog.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using HotelLandonBlog.Repository;
using Microsoft.AspNetCore;
using System.Web.Mvc;
using System.Web.Http.ModelBinding;
using Microsoft.EntityFrameworkCore;


namespace HotelLandonBlog.UI.Controllers
{
    public partial class BlogPostsController : GenericController<IRepository<BlogPost>, BlogPost>, IRazorController<BlogPost>
    {
        // Get
        public override async Task<IActionResult<BlogPost>> Edit(int id)
        {
            if (!entity.Id.Equals(id))
            {
                return View("NotFound");
            }
            if (ModelState.IsValid)
            {
                if (await this.repository.UpdateAsync(entity, id))
                {
                    return RedirectToAction("Read", "Home");
                }
            }
        }
    }
    

    [HttpPost("[action]/{id?}")]
    public override async Task<IActionResult> Edit([Bind(new[] {
            nameof(BlogPost.Id),
            nameof(BlogPost.Status),
            nameof(BlogPost.Category),
            nameof(BlogPost.Title),
            nameof(BlogPost.Content),
            nameof(BlogPost.LastUpdate),})] BlogPost entity, int id)=> base.Edit(id, entity);
    //{
    //    //if (ModelState.IsValid)
    //    //{
    //    //    db.Entry(entity).State = EntityState.Modified;
    //    //    db.SaveChanges();
    //    //    return RedirectToAction("Index");
    //    //}
    //    //return View(entity);
    //}
  //  
}

