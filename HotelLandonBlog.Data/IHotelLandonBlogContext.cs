using HotelLandonBlog.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelLandonBlog.Data
{

    public class HotelLandonBlogContext 
    {

        protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:tvitf1a81j.database.windows.net,1433;Initial Catalog=HotelLandon-2022;Persist Security Info=False;User ID=andrestalavera-sql;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        public interface IHotelLandonBlogContext
        {
            DbSet<BlogPost> Posts { get; set; }
            DbSet<Category> Categories { get; set; }

        }
   
    
       
    }

}
