using HotelLandonBlog.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelLandonBlog.Data
{
    public class IHotelLandonBlogContext : DbContext
    {
        public DbSet<BlogPost> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }


        public IHotelLandonBlogContext(DbContextOptions<IHotelLandonBlogContext> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }

}