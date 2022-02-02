using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelLandonBlog.UI.Controllers
{
    public interface IRazorController<TEntity>
    {
        Task<ActionResult<IEnumerable<TEntity>>> Index(string? search);
        Task<ActionResult<TEntity>> Details(int id);
        Task<ActionResult<TEntity>> Create();
        Task<ActionResult<TEntity>> Create(TEntity t);
        Task<ActionResult<TEntity>> Edit(int id);
        Task<ActionResult<TEntity>> Edit(int id, TEntity t);
        Task<ActionResult<TEntity>> Delete(int id);
        Task<ActionResult<TEntity>> Undelete(int id);
    }
}