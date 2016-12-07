using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.ViewModels
{
    public class IndexViewModels
    {
        public IEnumerable<Blog.Models.Post> Posts { get; set; }
        public IEnumerable<Blog.Models.Tag> Tags { get; set; }
        public IEnumerable<Blog.Models.Category> Categories { get; set; }
    }
}