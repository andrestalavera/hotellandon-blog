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
        // Get All (BlogPosts)
        [HttpGet, Route("/blogposts/")]
        [HttpGet, Route("/blogposts/home/")]
        [HttpGet, Route("/blogposts/home/index")]

        public Task<ActionResult<IEnumerable<BlogPost>>> Index(string search)
        {


            return base.Index(search);
        }

        // Get by id
        [HttpGet, Route("/blogposts/Edit/{id}")]

        public Task<ActionResult<BlogPost>> Details(int id)
        {

            return base.Details(id);
        }
    }
}
