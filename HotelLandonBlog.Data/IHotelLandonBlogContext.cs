using HotelLandonBlog.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelLandonBlog.Data
{
    public interface IHotelLandonBlogContext
    {
        DbSet<BlogPost> Posts { get; set; }
        DbSet<Category> Categories { get; set; }
    }

    public class HotelLandonBlogDbContext : DbContext, IHotelLandonBlogContext
    {
        public HotelLandonBlogDbContext(DbContextOptions<HotelLandonBlogDbContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}