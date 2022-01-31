using System;
using System.Collections.Generic;

namespace HotelLandonBlog.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime Creation { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
