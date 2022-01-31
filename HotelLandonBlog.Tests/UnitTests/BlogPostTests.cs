using HotelLandonBlog.Entities;
using HotelLandonBlog.UI;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace HotelLandonBlog.Tests.UnitTests
{
    public class BlogPostTests : WebApplicationTestsBase
    {
        private readonly BlogPostFaker blogPostFaker;
        public BlogPostTests(WebApplicationFactory<Startup> factory) : base(factory)
        {
            blogPostFaker = new();
        }

        #region edit
        [Fact]
        public async Task BlogPost_ContentMsutHaveTagsAsync()
        {
            // Arrange
            BlogPost blogPost = blogPostFaker.Generate();

            // Act
            Match match = Regex.Match(blogPost.Content, "<(\"[^\"]*\"|'[^']*'|[^'\">])*>");

            // Assert
            Assert.True(match.Success);
        }
        #endregion
    }
}