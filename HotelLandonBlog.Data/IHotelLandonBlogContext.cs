using HotelLandonBlog.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelLandonBlog.Data
{
    public class HotelLandonBlogContext : DbContext
    {
        public DbSet<BlogPost> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }

        public HotelLandonBlogContext(DbContextOptions<HotelLandonBlogContext>options)
        :base (options)
        {
        }
    }
}