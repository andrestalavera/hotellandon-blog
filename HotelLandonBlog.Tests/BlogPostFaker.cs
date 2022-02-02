using Bogus;
using HotelLandonBlog.Entities;
using System;

namespace HotelLandonBlog.Tests
{
    public class BlogPostFaker : Faker<BlogPost>
    {
        public BlogPostFaker() : base("fr")
        {
            RuleFor(blogpost => blogpost.Content, y => $"<div><p>{y.Lorem}</p></div>");
            RuleForType(typeof(string), f => f.Lorem.Paragraphs(1));
        }
    }
}