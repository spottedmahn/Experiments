using System.Collections.Generic;

namespace EF_Core_SomeId1.Models
{
    public class Blog : Entity
    {
        //public int BlogId { get; set; }

        public string Url { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}