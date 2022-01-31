using HotelLandonBlog.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelLandonBlog.Data
{

    public interface IHotelLandonBlogContext
    {
        public DbSet<BlogPost> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }

    }


    public class HotelLandonBlogContext : DbContext,IHotelLandonBlogContext
    {

        //public HotelLandonBlogContext(DbContextOptions<HotelLandonBlogContext>options)
        //:base (options)
        //{
        //}
        protected override OnConfiguring(DbContextOptionsBuilder optionsBuilder);

        public DbSet<BlogPost> Posts { get; set ; }
        public DbSet<Category> Categories { get ; set ; }
    }
}