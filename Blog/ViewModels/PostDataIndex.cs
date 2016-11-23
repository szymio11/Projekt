using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.ViewModels
{
    public class PostDataIndex
    {
        public int TagID { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }
    }
}