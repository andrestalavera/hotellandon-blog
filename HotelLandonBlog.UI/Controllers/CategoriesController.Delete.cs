using HotelLandonBlog.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HotelLandonBlog.UI.Controllers
{
    public partial class CategoriesController
    {
        public override Task<IActionResult> Delete(int id, [Bind("Id, CategoryId, Title,Content,LastUpdate")] Category t)
        {
            return base.Delete(id, t);
        }
    }
}
