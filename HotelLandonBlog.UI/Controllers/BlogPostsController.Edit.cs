using HotelLandonBlog.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using HotelLandonBlog.Repository;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;


namespace HotelLandonBlog.UI.Controllers
{
    public partial class BlogPostsController : GenericController<IRepository<BlogPost>, BlogPost>, IRazorController<BlogPost>
    {
        

        [HttpPost("[action]/{id?}")]
        public override Task<IActionResult> Edit(int id , [Bind(new[] {
            nameof(BlogPost.Id),
            nameof(BlogPost.Status),
            nameof(BlogPost.Category),
            nameof(BlogPost.Title),
            nameof(BlogPost.Content),
            nameof(BlogPost.LastUpdate),})] BlogPost entity) => base.Edit(id, entity);
    }
    

    
    
}

