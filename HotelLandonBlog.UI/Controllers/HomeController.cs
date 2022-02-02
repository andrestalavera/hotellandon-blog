using HotelLandonBlog.Data;
using HotelLandonBlog.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace HotelLandonBlog.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HotelLandonBlogDbContext context;

        public HomeController(HotelLandonBlogDbContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            this.context = context;
        }

        [HttpGet, Route("/")]
        [HttpGet, Route("/home/")]
        [HttpGet, Route("/home/index")]
        public IActionResult Index()
        {
            context.Posts.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
