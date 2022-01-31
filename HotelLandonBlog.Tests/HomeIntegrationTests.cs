using AutoFixture.Xunit2;
using HotelLandonBlog.UI;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace HotelLandonBlog.Tests
{
    public class HomeIntegrationTests : IntegrationTests
    {
        public HomeIntegrationTests(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Home_DefaultRoute_GET_OK()
        {
            // Arrange

            // Act
            HttpResponseMessage edit = await HttpClient.GetAsync($"/");

            // Assert
            Assert.NotNull(edit);
            Assert.Equal(HttpStatusCode.NotFound, edit.StatusCode);
        }

        [Fact]
        public async Task Home_ControllerRoute_GET_OK()
        {
            // Arrange

            // Act
            HttpResponseMessage edit = await HttpClient.GetAsync($"/home/");

            // Assert
            Assert.NotNull(edit);
            Assert.Equal(HttpStatusCode.NotFound, edit.StatusCode);
        }

        [Fact]
        public async Task Home_ControllerActionRoute_GET_OK()
        {
            // Arrange

            // Act
            HttpResponseMessage edit = await HttpClient.GetAsync($"/home/index");

            // Assert
            Assert.NotNull(edit);
            Assert.Equal(HttpStatusCode.NotFound, edit.StatusCode);
        }

        [Theory, AutoData]
        public async Task Random_ControllerRoute_GET_404(string controller)
        {
            // Arrange

            // Act
            HttpResponseMessage edit = await HttpClient.GetAsync($"/{controller}/");

            // Assert
            Assert.NotNull(edit);
            Assert.Equal(HttpStatusCode.NotFound, edit.StatusCode);
        }

        [Theory, AutoData]
        public async Task Random_ControllerActionRoute_GET_404(string controller, string action)
        {
            // Arrange

            // Act
            HttpResponseMessage edit = await HttpClient.GetAsync($"/{controller}/{action}");

            // Assert
            Assert.NotNull(edit);
            Assert.Equal(HttpStatusCode.NotFound, edit.StatusCode);
        }
    }
}