﻿using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public class Post
    {
        public Post()
        {
            this.Tags = new HashSet<Tag>();
        }
        public int PostID { get; set; }
        public ApplicationUser User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Category Category { get; set; }
        public int CategoryID { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}