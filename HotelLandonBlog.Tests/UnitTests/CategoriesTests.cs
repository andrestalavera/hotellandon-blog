using AutoFixture.Xunit2;
using HotelLandonBlog.Entities;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace HotelLandonBlog.Tests.UnitTests
{
    public class CategoriesTests
    {
        private const string categoryNamePattern = "[a-zA-Z @()!?,.;:-]{3,}";

        private readonly CategoriesFaker categoriesFaker;

        [InlineData("a")]
        [InlineData("b")]
        [InlineData("ab")]
        [InlineData("abc")]
        public void Category_Name_MinLenght_RegexMatch_Success(string categoryName)
        {
            // Arrange
            Category category = categoriesFaker.Generate();

            // Act
            Match match = Regex.Match(category.Name, categoryNamePattern);

            // Assert
            Assert.True(match.Success);
        }

        [InlineData("Abc")]
        public void Category_Name_MatchRegex_Success(string categoryName)
        {
            // Arrange
            Category category = new()
            {
                Id = 1,
                Name = categoryName
            };

            // Act
            Match match = Regex.Match(category.Name.Trim(), "[a-zA-Z @()!?,.;:-]{3,}");

            // Assert
            Assert.True(match.Success);
        }

        [InlineData("1")]
        public async Task Category_Name_MatchRegex_NotSucess(string categoryName)
        {

        }
    }
}