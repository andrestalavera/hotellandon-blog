using HotelLandonBlog.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HotelLandonBlog.UI.Controllers
{
    public partial class CategoriesController
    {
        // Get
        public override Task<IActionResult> Delete (int id,[Bind("Id,Name")]Category t)
        {
            return base.Delete(id, t);
        }

        // Post
       
    }
}
