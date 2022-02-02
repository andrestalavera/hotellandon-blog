using HotelLandonBlog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using static HotelLandonBlog.Data.HotelLandonBlogDbContext;

namespace HotelLandonBlog.Data
{

    public class HotelLandonBlogDbContext : DbContext, IHotelLandonBlogContext
    {
        public DbSet<BlogPost> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }

        public interface IHotelLandonBlogContext
        {
            DbSet<BlogPost> Posts { get; set; }
            DbSet<Category> Categories { get; set; }

        }

        
    }
}