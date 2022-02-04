﻿using HotelLandonBlog.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HotelLandonBlog.UI.Controllers
{
    public partial class CategoriesController
    {


        public override Task<IActionResult> Edit(int id, [Bind("Id,Name,CategoryId,Title,Content,LastUpdate")] Category t)
        {
            return base.Edit(id, t);

        }

    }


}

