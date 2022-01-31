using AutoFixture.Xunit2;
using HotelLandonBlog.Data;
using HotelLandonBlog.Entities;
using HotelLandonBlog.Repository;
using HotelLandonBlog.UI;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace HotelLandonBlog.Tests
{
    public class IntegrationTests
    {
        protected readonly HttpClient HttpClient;
        protected readonly IRepository<BlogPost> Repository;
        public IntegrationTests(WebApplicationFactory<Startup> factory)
        {
            HttpClient = factory.CreateClient();

            DbContextOptionsBuilder<HotelLandonBlogDbContext> builder = new DbContextOptionsBuilder<HotelLandonBlogDbContext>();
            builder.UseInMemoryDatabase("InMemoryDatabase");

            HotelLandonBlogDbContext context = new HotelLandonBlogDbContext(builder.Options);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.AddRange(MockData.FakeCategories);
            context.AddRange(MockData.FakeBlogPosts);

            context.SaveChanges();
        }
    }
}