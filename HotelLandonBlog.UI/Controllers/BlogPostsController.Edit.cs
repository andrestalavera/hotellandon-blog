using HotelLandonBlog.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HotelLandonBlog.UI.Controllers
{
    public partial class BlogPostsController
    {
        // Get
        public Task<ActionResult<BlogPost>> Edit(int id)
        {
            throw new NotImplementedException();
        }

        // Post
        public Task<ActionResult<BlogPost>> Edit(int id, BlogPost t)
        {
            throw new NotImplementedException();
        }
    }
}
