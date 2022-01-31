using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelLandonBlog.UI.Controllers
{
    public interface IRazorController<T>
    {
        Task<ActionResult<IEnumerable<T>>> Index(string? search);
        Task<ActionResult<T>> Details(int id);
        Task<ActionResult<T>> Create(int id);
        Task<ActionResult<T>> Create(int id, T t);
        Task<ActionResult<T>> Edit(int id);
        Task<ActionResult<T>> Edit(int id, T t);
        Task<ActionResult<T>> Delete(int id);
        Task<ActionResult<T>> Delete();
    }
}
