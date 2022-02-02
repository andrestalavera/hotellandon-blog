using AutoFixture.Xunit2;
using HotelLandonBlog.Entities;
using HotelLandonBlog.UI;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace HotelLandonBlog.Tests.IntegrationTests
{
    public class BlogPostTests : WebApplicationTestsBase
    {
        protected const string controllerName = "blogposts",
            indexActionResultName = "index",
            detailsActionResultName = "details",
            editActionResultName = "edit",
            createActionResultName = "create",
            deleteActionResultName = "delete",
            categoryId = "categoryId",
            showIsDeleted = "showIsDeleted",
            id = "id",
            search = "search",
            searchValue = "lorem",
            fakeCategoryIdValue = "1",
            fakeShowIsDeletedValue = "true",
            fakeWellId = "1",
            fakeWrongId = "100",
            fakeBadFormatId = "foo";

        public BlogPostTests(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        #region index
        [Fact]
        public Task BlogPosts_GetIndex_ControllerActionRoute_CategoryIdAndSearchParams_ReturnsOk()
            => ExecuteTest<BlogPost>(url: BuildUrl(controllerName, indexActionResultName), routes: new()
            {
                [categoryId] = fakeCategoryIdValue,
                [search] = searchValue
            });


        [Fact]
        public Task BlogPosts_GetIndex_ControllerRoute_CategoryIdAndSearchParams_ReturnsOk()
            => ExecuteTest<BlogPost>(url: BuildUrl(controllerName, routes: new()
            {
                [categoryId] = fakeCategoryIdValue,
                [search] = searchValue
            }));

        [Fact]
        public Task BlogPosts_GetIndex_ControllerActionRoute_NoParams_ReturnsOk()
            => ExecuteTest<BlogPost>(url: BuildUrl(controllerName, indexActionResultName));

        [Fact]
        public Task BlogPosts_GetIndex_ControllerActionRout_WithShowIsDeletedParam_ReturnsOk()
            => ExecuteTest<BlogPost>(url: BuildUrl(controllerName, indexActionResultName, new()
            {
                [showIsDeleted] = fakeShowIsDeletedValue
            }));

        [Fact]
        public Task BlogPosts_GetIndex_ControllerActionRoute_SearchParam_ReturnsOk()
            => ExecuteTest<BlogPost>(url: BuildUrl(controllerName, indexActionResultName, new()
            {
                [search] = searchValue
            }));
        #endregion

        #region details
        [Fact]
        public Task BlogPosts_GetDetails_ControllerActionIdRoute_ShowIsDeletedParam_ReturnsOk()
            => ExecuteTest<BlogPost>(url: BuildUrl(controllerName, detailsActionResultName, new()
            {
                [showIsDeleted] = fakeWellId
            }));

        [Fact]
        public Task BlogPosts_GetDetails_ControllerActionIdRoute_IdIsString_ReturnsBadRequest()
            => ExecuteTest<BlogPost>(url: BuildUrl(controllerName, detailsActionResultName, new()
            {
                [id] = fakeBadFormatId
            }));

        [Fact]
        public Task BlogPosts_GetDetails_ControllerActionIdRoute_NotExists_ReturnsNotFound()
            => ExecuteTest<BlogPost>(url: BuildUrl(controllerName, detailsActionResultName, new()
            {
                [id] = fakeWrongId
            }));
        #endregion

        #region create
        [Fact]
        public Task BlogPost_GetCreate_ReturnsOk()
            => ExecuteTest<BlogPost>(url: BuildUrl(controllerName, createActionResultName));

        [Theory, AutoData]
        public Task BlogPost_PostCreate_ReturnsCreated(BlogPost blogPost)
            => ExecuteTest(url: BuildUrl(controllerName, createActionResultName), expected: HttpStatusCode.Created, content: blogPost, method: HttpMethod.POST);

        [Theory, AutoData]
        public async Task BlogPost_PostCreate_WrongCreationAndId_ReturnsBadRequest(BlogPost blogPost)
        {
            // Arrange
            blogPost.Id = -1;
            blogPost.Creation = new DateTime();

            // Act
            await ExecuteTest(url: BuildUrl(controllerName, action: detailsActionResultName, new()
            {
                [showIsDeleted] = fakeWellId
            }), method: HttpMethod.POST, content: blogPost);
        }

        [Fact]
        public Task BlogPost_PostCreate_BlogPostHasEmptyValues_ReturnsBadRequest()
            => ExecuteTest<BlogPost>(url: BuildUrl(controllerName, detailsActionResultName, new()
            {
                [showIsDeleted] = fakeWellId
            }), method: HttpMethod.POST, content: new());

        #endregion

        #region edit
        [Fact]
        public Task BlogPost_GetEdit_ReturnsOk()
            => ExecuteTest<BlogPost>(url: BuildUrl(controllerName, editActionResultName, new()
            {
                [id] = fakeWellId
            }), ensureSuccessStatusCode: true);

        [Fact]
        public async Task BlogPost_GetEdit_IdStringString_ReturnsBadRequest()
        {
            BlogPost blogPost = await Repository.GetAsync(1);
            blogPost.Title = "";

            await ExecuteTest(url: BuildUrl(controllerName, editActionResultName, new()
            {
                [id] = fakeWellId,
            }), content: blogPost);
        }

        [Fact]
        public Task BlogPost_GetEdit_ReturnsNotFound()
            => ExecuteTest<BlogPost>(url: BuildUrl(controllerName, editActionResultName, new()
            {
                [id] = fakeWrongId,
            }));

        [Theory, AutoData]
        public async Task BlogPost_PostEdit_ReplaceTitle_ReturnsOk(string newTitle)
        {
            BlogPost blogPost = await Repository.GetAsync(1);
            blogPost.Title = newTitle;

            await ExecuteTest(url: BuildUrl(controllerName, editActionResultName, new() { [id] = fakeWellId }), method: HttpMethod.POST, content: blogPost);
        }

        [Fact]
        public async Task BlogPost_PostEdit_EmptyCreationDate_ReturnsBadRequest()
        {
            BlogPost blogPost = await Repository.GetAsync(1);
            blogPost.Creation = new();

            await ExecuteTest(url: BuildUrl(controllerName, editActionResultName, new() { [id] = fakeWellId }), expected: HttpStatusCode.BadRequest, method: HttpMethod.POST, content: blogPost);
        }

        [Fact]
        public async Task BlogPost_PostEdit_EmptyTitle_ReturnsBadRequest()
        {
            BlogPost blogPost = await Repository.GetAsync(1);
            blogPost.Title = string.Empty;

            await ExecuteTest(url: BuildUrl(controllerName, editActionResultName, new() { [id] = fakeWellId }), expected: HttpStatusCode.BadRequest, method: HttpMethod.POST, content: blogPost);
        }

        [Fact]
        public async Task BlogPost_PostEdit_EmptyContent_ReturnsBadRequest()
        {
            BlogPost blogPost = await Repository.GetAsync(1);
            blogPost.Content = string.Empty;

            await ExecuteTest(url: BuildUrl(controllerName, editActionResultName, new() { [id] = fakeWellId }), expected: HttpStatusCode.BadRequest, method: HttpMethod.POST, content: blogPost);
        }
        #endregion
    }
}