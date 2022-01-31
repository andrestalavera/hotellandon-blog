using HotelLandonBlog.Entities;
using HotelLandonBlog.UI;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace HotelLandonBlog.Tests
{
    public class CategoriesTests : IntegrationTests
    {
        public CategoriesTests(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Categories_Index_ControllerActionRoute_OK()
        {
            // Arrange

            // Act
            IEnumerable<Category> categories = await HttpClient.GetFromJsonAsync<IEnumerable<Category>>("/customers/index");

            // Assert
            Assert.NotNull(categories);
        }

        [Fact]
        public async Task Categories_Index_ControllerActionRouteWithFilter_OK()
        {
            // Arrange

            // Act
            IEnumerable<Category> categories = await HttpClient.GetFromJsonAsync<IEnumerable<Category>>("/customers/index?search=lorem");

            // Assert
            Assert.NotNull(categories);
        }
    }
}