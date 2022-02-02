using AutoFixture.Xunit2;
using HotelLandonBlog.Entities;
using HotelLandonBlog.UI;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.RegularExpressions;
using Xunit;

namespace HotelLandonBlog.Tests.UnitTests
{
    public class BlogPostTests : WebApplicationTestsBase
    {
        private readonly BlogPostFaker blogPostFaker;

        public BlogPostTests(WebApplicationFactory<Startup> factory) : base(factory) => blogPostFaker = new();

        #region edit
        [Fact]
        public void BlogPost_ContentMustHaveTags()
        {
            // Arrange
            BlogPost blogPost = blogPostFaker.Generate();

            // Act
            Match match = Regex.Match(blogPost.Content, "<(\"[^\"]*\"|'[^']*'|[^'\">])*>");

            // Assert
            Assert.True(match.Success);
        }

        [Theory, AutoData]
        public void BlogPost_Name_CanHaveHaveNumbers(Category category)
        {
            // Arrange

            // Act
            Match match = Regex.Match(category.Name.Trim(), "[a-zA-Z0-9 @()!?,.;:-]");

            // Assert
            Assert.True(match.Success);
        }

        [Fact]
        public void BlogPost_TitleMustHaveMin5Characters()
        {
            //
            BlogPost blogPost = blogPostFaker.Generate();

            // Act
            var has5characters = blogPost.Title.Trim().Length >= 5;
            Match match = Regex.Match(blogPost.Title.Trim(), "[a-zA-Z @()!?,.;:-]{5,}");

            // Assert
            Assert.True(has5characters);
            Assert.True(match.Success);
        }
        #endregion
    }
}