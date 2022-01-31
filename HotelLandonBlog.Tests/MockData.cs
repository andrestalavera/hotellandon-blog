using HotelLandonBlog.Entities;
using System.Collections.Generic;
using Bogus;
using Bogus.DataSets;

namespace HotelLandonBlog.Tests
{
    public static class MockData
    {
        private static Faker Faker => new();
        private static Lorem LoremDataSet => new("fr");
        public static List<BlogPost> FakeBlogPosts => new()
        {
            new()
            {
                Id = 1,
                CategoryId = Faker.PickRandomParam(FakeCategories.ToArray()).Id,
                Status = Faker.PickRandomWithout<BlogPostStatus>(),
                Title = LoremDataSet.Sentence(5),
                Content = LoremDataSet.Paragraphs(5),
            },
            new()
            {
                Id = 2,
                CategoryId = Faker.PickRandomParam(FakeCategories.ToArray()).Id,
                Status = Faker.PickRandomWithout<BlogPostStatus>(),
                Title = LoremDataSet.Sentence(5),
                Content = LoremDataSet.Paragraphs(5),
            },
            new()
            {
                Id = 3,
                CategoryId = Faker.PickRandomParam(FakeCategories.ToArray()).Id,
                Status = Faker.PickRandomWithout<BlogPostStatus>(),
                Title = LoremDataSet.Sentence(5),
                Content = LoremDataSet.Paragraphs(5),
            },
            new()
            {
                Id = 4,
                CategoryId = Faker.PickRandomParam(FakeCategories.ToArray()).Id,
                Status = Faker.PickRandomWithout<BlogPostStatus>(),
                Title = LoremDataSet.Sentence(5),
                Content = LoremDataSet.Paragraphs(5),
            },
            new()
            {
                Id = 5,
                CategoryId = Faker.PickRandomParam(FakeCategories.ToArray()).Id,
                Status = Faker.PickRandomWithout<BlogPostStatus>(),
                Title = LoremDataSet.Sentence(5),
                Content = LoremDataSet.Paragraphs(5),
            },
            new()
            {
                Id = 6,
                CategoryId = Faker.PickRandomParam(FakeCategories.ToArray()).Id,
                Status = Faker.PickRandomWithout<BlogPostStatus>(),
                Title = LoremDataSet.Sentence(5),
                Content = LoremDataSet.Paragraphs(5),
            },
            new()
            {
                Id = 7,
                CategoryId = Faker.PickRandomParam(FakeCategories.ToArray()).Id,
                Status = Faker.PickRandomWithout<BlogPostStatus>(),
                Title = LoremDataSet.Sentence(5),
                Content = LoremDataSet.Paragraphs(5),
            },
            new()
            {
                Id = 8,
                CategoryId = Faker.PickRandomParam(FakeCategories.ToArray()).Id,
                Status = Faker.PickRandomWithout<BlogPostStatus>(),
                Title = LoremDataSet.Sentence(5),
                Content = LoremDataSet.Paragraphs(5),
            },
            new()
            {
                Id = 9,
                CategoryId = Faker.PickRandomParam(FakeCategories.ToArray()).Id,
                Status = Faker.PickRandomWithout<BlogPostStatus>(),
                Title = LoremDataSet.Sentence(5),
                Content = LoremDataSet.Paragraphs(5),
            },
            new()
            {
                Id = 10,
                CategoryId = Faker.PickRandomParam(FakeCategories.ToArray()).Id,
                Status = Faker.PickRandomWithout<BlogPostStatus>(),
                Title = LoremDataSet.Sentence(5),
                Content = LoremDataSet.Paragraphs(5),
            }
        };

        public static List<Category> FakeCategories => new()
        {
            new()
            {
                Id = 1,
                Name = LoremDataSet.Word(),
            },
            new()
            {
                Id = 2,
                Name = LoremDataSet.Word(),
            },
            new()
            {
                Id = 3,
                Name = LoremDataSet.Word(),
            }
        };
    }
}