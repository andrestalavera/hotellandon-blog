using HotelLandonBlog.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HotelLandonBlog.UI.Controllers
{
    public partial class BlogPostsController
    {
        // Get
        public override Task<IActionResult> Delete(int id, [Bind("Id,Category,LastUpdate,Status,CategoryId,Title,Content")] BlogPost t)
        {
            return base.Delete(id, t);
        }
    }
}
