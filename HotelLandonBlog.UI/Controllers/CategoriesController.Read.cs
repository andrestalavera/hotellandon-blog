using HotelLandonBlog.Entities;
using HotelLandonBlog.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;


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
       

        public Task<ActionResult<IEnumerable<Category>>> Index(string search)
        {
            return base.Index(search);
        }

        // Get by id
        [HttpGet, Route("/Category/Edit/{id}")]

        public Task<ActionResult<Category>> Details(int id)
        {
            return base.Details(id);
        }
    }
}
