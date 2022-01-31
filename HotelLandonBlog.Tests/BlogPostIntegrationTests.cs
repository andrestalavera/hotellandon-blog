using AutoFixture.Xunit2;
using HotelLandonBlog.Entities;
using HotelLandonBlog.UI;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace HotelLandonBlog.Tests
{
    public class BlogPostIntegrationTests : IntegrationTests
    {
        public BlogPostIntegrationTests(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task BlogPosts_Index_ControllerActionRouteCategoryIdAndSearchParams_OK()
        {
            // Arrange

            // Act
            HttpResponseMessage index = await HttpClient.GetAsync("/blogposts/index?categoryID=1&search=lorem");
            index.EnsureSuccessStatusCode();

            // Assert
            Assert.NotNull(index);
            Assert.Equal(HttpStatusCode.OK, index.StatusCode);
        }

        [Fact]
        public async Task BlogPosts_Index_ControllerRouteOnly_OK()
        {
            // Arrange

            // Act
            HttpResponseMessage index = await HttpClient.GetAsync("/blogposts");
            index.EnsureSuccessStatusCode();

            // Assert
            Assert.NotNull(index);
            Assert.Equal(HttpStatusCode.OK, index.StatusCode);
        }

        [Fact]
        public async Task BlogPosts_Index_ControllerActionRoute_OK()
        {
            // Arrange

            // Act
            HttpResponseMessage index = await HttpClient.GetAsync("/blogposts/index");
            index.EnsureSuccessStatusCode();

            // Assert
            Assert.NotNull(index);
            Assert.Equal(HttpStatusCode.OK, index.StatusCode);
        }

        [Fact]
        public async Task BlogPosts_Index_ControllerActionWithShowIsDeleted_OK()
        {
            // Arrange

            // Act
            HttpResponseMessage index = await HttpClient.GetAsync("/blogposts/index?showIsDeleted=true");
            index.EnsureSuccessStatusCode();

            // Assert
            Assert.NotNull(index);
            Assert.Equal(HttpStatusCode.OK, index.StatusCode);
        }

        [Fact]
        public async Task BlogPosts_Index_ControllerActionWithCategoryFilter_OK()
        {
            // Arrange

            // Act
            HttpResponseMessage index = await HttpClient.GetAsync("/blogposts/index?search=lorem");
            index.EnsureSuccessStatusCode();

            // Assert
            Assert.NotNull(index);
            Assert.Equal(HttpStatusCode.OK, index.StatusCode);
        }

        [Fact]
        public async Task BlogPosts_Details_OK()
        {
            // Arrange

            // Act
            HttpResponseMessage details = await HttpClient.GetAsync("/blogposts/1");
            details.EnsureSuccessStatusCode();

            // Assert
            Assert.NotNull(details);
            Assert.Equal(HttpStatusCode.OK, details.StatusCode);
        }

        [Fact]
        public async Task BlogPosts_Details_IdIsString()
        {
            // Act
            HttpResponseMessage details = await HttpClient.GetAsync("/blogposts/foo");
            details.EnsureSuccessStatusCode();

            // Assert
            Assert.NotNull(details);
            Assert.Equal(HttpStatusCode.BadRequest, details.StatusCode);
        }

        [Fact]
        public async Task BlogPosts_Details_404()
        {
            // Act
            HttpResponseMessage index = await HttpClient.GetAsync("/blogposts/100");
            index.EnsureSuccessStatusCode();

            // Assert
            Assert.NotNull(index);
            Assert.Equal(HttpStatusCode.NotFound, index.StatusCode);
        }

        [Theory, AutoData]
        public async Task BlogPost_Create_POST_OK(BlogPost blogPost)
        {
            // Arrange

            // Act
            HttpResponseMessage create = await HttpClient.PostAsJsonAsync("blogposts", blogPost);
            create.EnsureSuccessStatusCode();

            // Assert
            Assert.NotNull(create);
            Assert.Equal(HttpStatusCode.Created, create.StatusCode);
        }

        [Theory, AutoData]
        public async Task BlogPost_Create_POST_BadRequest(BlogPost blogPost)
        {
            // Arrange
            blogPost.Id = -1;

            // Act
            HttpResponseMessage create = await HttpClient.PostAsJsonAsync("blogposts", blogPost);

            // Assert
            Assert.NotNull(create);
            Assert.Equal(HttpStatusCode.BadRequest, create.StatusCode);
        }

        [Fact]
        public async Task BlogPost_Create_POST_BlogPostHasEmptyValues()
        {
            // Arrange

            // Act
            HttpResponseMessage create = await HttpClient.PostAsJsonAsync<BlogPost>("blogposts", new());

            // Assert
            Assert.NotNull(create);
            Assert.Equal(HttpStatusCode.BadRequest, create.StatusCode);
        }

        [Theory, AutoData]
        public async Task BlogPost_Edit_GET_OK(string newTitle)
        {
            // Arrange
            BlogPost blogPost = (await Repository.GetAllAsync()).First();
            blogPost.Title = newTitle;

            // Act
            HttpResponseMessage edit = await HttpClient.GetAsync($"blogposts/{blogPost.Id}");
            edit.EnsureSuccessStatusCode();

            // Assert
            Assert.NotNull(edit);
            Assert.Equal(HttpStatusCode.OK, edit.StatusCode);
        }

        [Theory, AutoData]
        public async Task BlogPost_Edit_GET_IdStringString(string newTitle)
        {
            // Arrange

            // Act
            HttpResponseMessage edit = await HttpClient.GetAsync("blogposts/foo");

            // Assert
            Assert.NotNull(edit);
            Assert.Equal(HttpStatusCode.BadRequest, edit.StatusCode);
        }

        [Theory, AutoData]
        public async Task BlogPost_Edit_GET_404(string newTitle)
        {
            // Arrange

            // Act
            HttpResponseMessage edit = await HttpClient.GetAsync("blogposts/100");

            // Assert
            Assert.NotNull(edit);
            Assert.Equal(HttpStatusCode.NotFound, edit.StatusCode);
        }
    }
}