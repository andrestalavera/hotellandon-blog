using HotelLandonBlog.UI;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace HotelLandonBlog.Tests.IntegrationTests
{
    public class CategoriesTests : WebApplicationTestsBase
    {
        private const string categoryControllerName = "categories",
            indexActionResultName = "index",
            detailActionResultName = "details",
            createActionResultName = "create",
            editActionResultName = "edit",
            searchParameterName = "search",
            fakeSearchValue = "lorem",
            id = "id",
            fakeIdValue = "1",
            fakeIdValueNotFound = "100";

        public CategoriesTests(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public Task Categories_GetIndex_ControllerActionRoute_ReturnsOk() => ExecuteTest<string>(url: BuildUrl(categoryControllerName, indexActionResultName));

        [Fact]
        public Task Categories_GetIndex_ControllerActionRoute_SearchParam_ReturnsOk() => ExecuteTest<string>(url: BuildUrl(categoryControllerName, indexActionResultName, new() { [searchParameterName] = fakeSearchValue }));

        [Fact]
        public Task Categories_GetDetails_ControllerActionIdRoute_ReturnsOk() => ExecuteTest<string>(url: BuildUrl(categoryControllerName, detailActionResultName, new() { [id] = fakeIdValue }));

        [Fact]
        public Task Categories_GetDetails_ControllerActionIdRoute_ReturnsNotFound() => ExecuteTest<string>(url: BuildUrl(categoryControllerName, detailActionResultName, new() { [id] = fakeIdValueNotFound }), expected: HttpStatusCode.NotFound);

        [Fact]
        public Task Categories_GetCreate_ControllerActionIdRoute_ReturnsOk() => ExecuteTest<string>(url: BuildUrl(categoryControllerName, createActionResultName, new() { [id] = fakeIdValue }));

        [Fact]
        public Task Categories_GetCreate_ControllerActionIdRoute_ReturnsNotFound() => ExecuteTest<string>(url: BuildUrl(categoryControllerName, detailActionResultName, new() { [id] = fakeIdValueNotFound }), expected: HttpStatusCode.NotFound);

        [Fact]
        public Task Categories_GetEdit_ControllerActionIdRoute_ReturnsOk() => ExecuteTest<string>(url: BuildUrl(categoryControllerName, editActionResultName, new() { [id] = fakeIdValue }));
    }
}