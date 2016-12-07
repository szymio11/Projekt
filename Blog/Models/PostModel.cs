using System.Collections.Generic;
using Blog.Models;

namespace Blog.Controllers
{
    public class PostModel
    {
        public List<Category> Categories { get; set; }
        public List<Post> Posts { get; set; }
        public List<Tag> Tags { get; set; }
    }
}