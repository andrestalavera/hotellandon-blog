using HotelLandonBlog.Entities;
using HotelLandonBlog.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HotelLandonBlog.UI.Controllers
{
    public partial class BlogPostsController : GenericController<IRepository<BlogPost>, BlogPost>, IRazorController<BlogPost>
    {
        // Get
        [HttpGet]
        public override Task<ActionResult<BlogPost>> Create()
        {
            return View(default(BlogPost));
        }
        // Post
        [HttpPost("[action]/{id}")]
        public override Task<ActionResult<BlogPost>> Create([Bind(new[] {
            nameof(BlogPost.Id),
            nameof(BlogPost.CategoryId),
            nameof(BlogPost.Category),
            nameof(BlogPost.Content),
            nameof(BlogPost.LastUpdate),
            nameof(BlogPost.Title),
            nameof(BlogPost.Status)})] BlogPost entity, int id) => base.Create(entity, id);
    }

}
