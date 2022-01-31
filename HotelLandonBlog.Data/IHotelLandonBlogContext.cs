using HotelLandonBlog.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelLandonBlog.Data
{
    public interface IHotelLandonBlogContext
    {
        DbSet<BlogPost> Posts { get; set; }
        DbSet<Category> Categories { get; set; }
    }
}