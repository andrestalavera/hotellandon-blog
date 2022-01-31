using HotelLandonBlog.Data;
using HotelLandonBlog.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLandonBlog.UI.Controllers
{
    public interface IController<TEntity>
        where TEntity : EntityBase, new()
    {
        Task<ActionResult<IEnumerable<TEntity>>> Get(string? searchTerm = null, BlogPostStatus? status = null, int? categoryId = null);
        Task<ActionResult<TEntity>> Details(int id);
        Task<ActionResult<TEntity>> Create();
        Task<IActionResult> Create(TEntity t);
        Task<ActionResult<TEntity>> Edit(int id);
        Task<IActionResult> Edit(int id, TEntity t);
        Task<ActionResult> Delete(int id);
        Task<IActionResult> DeleteConfirmed(int id);
    }
}
