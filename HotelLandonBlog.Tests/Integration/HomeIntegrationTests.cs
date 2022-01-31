using AutoFixture.Xunit2;
using HotelLandonBlog.UI;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace HotelLandonBlog.Tests.IntegrationTests
{
    public class HomeIntegrationTests : WebApplicationTestsBase
    {
        private const string homeControllerName = "home",
            indexActionResultName = "index",
            privacyActionResultName = "privacy";
        public HomeIntegrationTests(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public Task Home_GetIndex_EmptyRoute_NoParams_ReturnsOk() => ExecuteTest<string>(url: "/");

        [Fact]
        public Task Home_GetIndex_ControllerRoute_NoParams_ReturnsOk() => ExecuteTest<string>(url: BuildUrl(homeControllerName));

        [Fact]
        public Task Home_GetIndex_ControllerActionRoute_NoParams_ReturnsOk() => ExecuteTest<string>(url: BuildUrl(homeControllerName, indexActionResultName));

        [Fact]
        public Task Home_GetPrivacy_ActionRoute_NoParams_ReturnsNotFound() => ExecuteTest<string>(url: BuildUrl(action: privacyActionResultName), expected: HttpStatusCode.NotFound);

        [Fact]
        public Task Home_GetPrivacy_ControllerActionRoute_NoParams_ReturnsOk() => ExecuteTest<string>(url: BuildUrl(homeControllerName, privacyActionResultName));

        [Theory, AutoData]
        public Task Random_GetRandom_ControllerRoute_ReturnsNotFound(string controller) => ExecuteTest<string>(url: BuildUrl(controller), expected: HttpStatusCode.NotFound);

        [Theory, AutoData]
        public Task Random_GetRandom_ControllerActionRoute_ReturnsNotFound(string controller, string action) => ExecuteTest<string>(url: BuildUrl(controller, action), expected: HttpStatusCode.NotFound);
    }
}