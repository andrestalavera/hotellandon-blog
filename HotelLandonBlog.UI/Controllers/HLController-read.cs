
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
    public partial class HLController : Controller
    {
        // Get
        // Get All (search)

        Category category1 = new Category()
        {
            Name = "Lassina"
    
        };

        RepositoryBase<Category> repository = new ();


    }
}
