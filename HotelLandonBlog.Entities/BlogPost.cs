using System;

namespace HotelLandonBlog.Entities
{
    public class BlogPost : EntityBase
    {
        public BlogPostStatus Status { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
