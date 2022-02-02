
using HotelLandonBlog.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace HotelLandonBlog.UI.Controllers
{
    public partial class BlogPostsController : Controller, IRazorController<BlogPost>
    {
        // Get Undelete/Id
        public Task<ActionResult<BlogPost>> Undelete(int id)
        {
            throw new NotImplementedException();
        }

        // Post Undelete/Id
        public Task<ActionResult<BlogPost>> Undelete(int id, BlogPost blogPost)
        {
            throw new NotImplementedException();
        }
    }
}
