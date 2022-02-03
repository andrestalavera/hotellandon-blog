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
    public partial class BlogPostsController : GenericController<IRepository<BlogPost>, BlogPost>
    {
        public BlogPostsController(IRepository<BlogPost> repository, ILogger<GenericController<IRepository<BlogPost>, BlogPost>> logger) : base(repository, logger)
        {
        }
        // Get
        // Get All (search)
        public Task<ActionResult<IEnumerable<BlogPost>>> Index(string search)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Details(int id)
        {
            throw new NotImplementedException();
        }
    }
}
