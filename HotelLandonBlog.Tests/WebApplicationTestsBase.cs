using HotelLandonBlog.Data;
using HotelLandonBlog.Entities;
using HotelLandonBlog.Repository;
using HotelLandonBlog.UI;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace HotelLandonBlog.Tests
{
    public abstract class WebApplicationTestsBase : IClassFixture<WebApplicationFactory<Startup>>
    {
        protected readonly HttpClient HttpClient;
        protected readonly IRepository<BlogPost> Repository;

        public WebApplicationTestsBase(WebApplicationFactory<Startup> factory)
        {
            HttpClient = factory.CreateClient();

            DbContextOptionsBuilder<HotelLandonBlogDbContext> builder = new();
            builder.UseInMemoryDatabase("InMemoryDatabase");

            HotelLandonBlogDbContext context = new(builder.Options);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.AddRange(MockData.FakeCategories);
            context.AddRange(MockData.FakeBlogPosts);

            context.SaveChanges();
        }

        protected string BuildUrl(string controller = "",
            string action = "",
            Dictionary<string, string>? routes = null)
        {
            string url = string.Empty;
            if (!string.IsNullOrEmpty(controller))
            {
                url += $"/{controller}/";
            }
            if (!string.IsNullOrEmpty(action))
            {
                url += $"/{action}/";
            }
            if (routes is not null && routes.TryGetValue("id", out string id))
            {
                url += id;
            }
            int i = 0;
            if (routes is not null && routes.Any())
            {
                foreach (var route in routes.Where(e => e.Key != "id"))
                {
                    url += $"{(i == 0 ? "$" : "&")}{route.Key}={route.Value}";
                }
            }
            url = url.Replace("//", "/");
            return url;
        }

        protected async Task ExecuteTest<T>(
            HttpStatusCode expected = HttpStatusCode.OK,
            HttpMethod method = HttpMethod.GET,
            string url = "",
            bool ensureSuccessStatusCode = false,
            Dictionary<string, string>? routes = null,
            T? content = default)
            where T : class
        {
            // Arrange
            Console.WriteLine($"Execute test for url: {method} `{url}`.");
            // Act
            HttpResponseMessage response = method switch
            {
                HttpMethod.GET => await HttpClient.GetAsync(url),
                HttpMethod.POST => await HttpClient.PostAsJsonAsync(url, content),
                HttpMethod.PUT => await HttpClient.PutAsJsonAsync(url, content),
                HttpMethod.DELETE => await HttpClient.DeleteAsync(url),
                _ => await HttpClient.GetAsync(url)
            };

            if (ensureSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
            }

            // Assert
            Assert.NotNull(response);
            Assert.Equal(expected, response.StatusCode);
        }
    }
}