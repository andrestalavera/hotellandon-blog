
using HotelLandonBlog.Entities;
using HotelLandonBlog.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Diagnostics;
using Microsoft.Extensions.Logging;


namespace HotelLandonBlog.UI.Controllers   
{
    public partial class BlogPostsController : Controller, IRazorController<BlogPost>
    {
        // Get
        // Get All (search)
        public Task<ActionResult<IEnumerable<BlogPost>>> Index(string search)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<BlogPost>> Details(int id)
        {
            throw new NotImplementedException();
        }
    }
}
