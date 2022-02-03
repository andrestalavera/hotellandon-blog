using HotelLandonBlog.Entities;
using HotelLandonBlog.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HotelLandonBlog.UI.Controllers
{
    public partial class BlogPostsController : GenericController<IRepository<BlogPost>, BlogPost>, IRazorController<BlogPost>
    {
        
       
            public override Task<IActionResult> Create([Bind(new[] {
            nameof(BlogPost.Id),
            nameof(BlogPost.CategoryId),
            nameof(BlogPost.Category),
            nameof(BlogPost.Content),
            nameof(BlogPost.LastUpdate),
            nameof(BlogPost.Title),
            nameof(BlogPost.Status)})] BlogPost entity) => base.Create(entity);
    }

}
