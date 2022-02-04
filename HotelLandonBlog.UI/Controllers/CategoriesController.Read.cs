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
    public partial class CategoriesController : GenericController<IRepository<Category>, Category>
    {
        public CategoriesController(IRepository<Category> repository, ILogger<GenericController<IRepository<Category>, Category>> logger) : base(repository, logger)
        {
        }
        // Get All (Category)
        [HttpGet, Route("/Category/")]
        [HttpGet, Route("/Category/home/")]
        public Task<IActionResult> Index(string search)
        {
            return base.Index(search);
        }

        public Task<IActionResult> Details(int id)
        {
            return base.Details(id);
        }
    }
}
