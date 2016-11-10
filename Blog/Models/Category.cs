using System.Collections.Generic;

namespace Blog.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}