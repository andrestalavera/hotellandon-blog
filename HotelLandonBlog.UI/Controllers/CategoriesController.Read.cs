
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
    public partial class CategoriesController : Controller, IRazorController<Category>
    {
        // Get
        // Get All (search)
        public Task<ActionResult<IEnumerable<Category>>> Index(string search)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Category>> Details(int id)
        {
            throw new NotImplementedException();
        }
    }
}
