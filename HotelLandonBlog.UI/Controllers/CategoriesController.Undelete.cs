
using HotelLandonBlog.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace HotelLandonBlog.UI.Controllers
{
    public partial class CategoriesController 
    {
        // Get Undelete/Id
        public Task<ActionResult<Category>> Undelete(int id)
        {
            throw new NotImplementedException();
        }

        // Post Undelete/Id
        public Task<ActionResult<Category>> Undelete(int id, Category blogPost)
        {
            throw new NotImplementedException();
        }
    }
}
