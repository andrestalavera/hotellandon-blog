using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelLandonBlog.UI.Controllers
{
    public interface IRazorController<TEntity>
    {
        Task<IActionResult> Index(string? search);
        Task<IActionResult> Details(int id);
        Task<IActionResult> Create();
        Task<IActionResult> Create(TEntity t);
        Task<IActionResult> Edit(int id);
        Task<IActionResult> Edit(int id, TEntity t);
        Task<IActionResult> Delete(int id);
        Task<IActionResult> Delete(int id, TEntity t);
        Task<IActionResult> Undelete(int id);
        Task<IActionResult> Undelete(int id, TEntity t);
    }
}