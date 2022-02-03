using HotelLandonBlog.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HotelLandonBlog.UI.Controllers
{
    public partial class BlogPostsController
    {
        // Get


        // Post
        public override Task<IActionResult> Delete(int id, [Bind("Id, CategoryId, Title,Content,LastUpdate")] BlogPost t)
        {
            return base.Delete(id, t);
        }
    }
}