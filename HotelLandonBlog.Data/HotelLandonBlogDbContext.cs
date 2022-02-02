using HotelLandonBlog.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelLandonBlog.Data
{
    public class HotelLandonBlogDbContext : DbContext, IHotelLandonBlogContext
    {
        public DbSet<BlogPost> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }

        public HotelLandonBlogDbContext(DbContextOptions<HotelLandonBlogDbContext> options) 
            : base(options)
        {

        }
    }
}