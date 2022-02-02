using Bogus;
using HotelLandonBlog.Entities;

namespace HotelLandonBlog.Tests
{
    public class CategoriesFaker : Faker<Category>
    {
        public CategoriesFaker() : base("fr")
        {
            RuleForType(typeof(string), f => f.Lorem.Words());
        }
    }
}