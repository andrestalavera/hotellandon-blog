using HotelLandonBlog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HotelLandonBlog.Migrator
{
    public class Program
    {
        public static async Task Main()
        {
            HotelLandonBlogDbContextFactory factory = new();
            HotelLandonBlogDbContext context = factory.CreateDbContext();

            await context.Database.EnsureCreatedAsync();
            await context.Database.MigrateAsync();
        }
    }

    public class HotelLandonBlogDbContextFactory : IDesignTimeDbContextFactory<HotelLandonBlogDbContext>
    {
        public HotelLandonBlogDbContext CreateDbContext(string[] args = null)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true)
                .AddUserSecrets("HotelLandon-Blog")
                .Build();

            DbContextOptionsBuilder<HotelLandonBlogDbContext> optionsBuilder = new();
            string connectionString = config.GetConnectionString("DefaultConnection");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                Console.WriteLine("La chaîne de connexion est vide. Vérifiez votre User-Secret.");
            }
            Console.WriteLine(connectionString);
            optionsBuilder.UseSqlServer(connectionString);

            return new HotelLandonBlogDbContext(optionsBuilder.Options);
        }
    }
}