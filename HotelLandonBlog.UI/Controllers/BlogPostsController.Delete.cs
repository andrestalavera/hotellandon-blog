using HotelLandonBlog.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HotelLandonBlog.UI.Controllers
{
    public partial class BlogPostsController
    {
        // Get
        public Task<ActionResult<BlogPost>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        // Post
        //post
        public Task<ActionResult<BlogPost>> Delete(int id, BlogPost blogPost)
        {
            throw new NotImplementedException();
        }
    }
}
