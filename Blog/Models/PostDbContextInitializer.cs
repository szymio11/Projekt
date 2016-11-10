using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class PostDbContextInitializer : DropCreateDatabaseIfModelChanges<PostDbContext>
    {
        protected override void Seed(PostDbContext context)
        {
            List<Category> listCategory = new List<Category>
            {
                new Category { Name = "Programming" },
                new Category { Name = "Designing" },
                new Category { Name = "Database" },
            };

            List<Tag> listTag = new List<Tag>
            {
                new Tag { Name = "Csharp" },
                new Tag { Name = "Asp.Net" },
                new Tag { Name = "Sencha Touch" },
                new Tag { Name = "MVC" },
                new Tag { Name = "SqlServer" },
                new Tag { Name = "Oracle" },
                new Tag { Name = "Bootstrap" },
                new Tag { Name = "Jquery" },
            };

            List<Post> listPost = new List<Post>
            {
                new Post { Title = "List Paging in Sencha Touch", Body = "In this one I am going to add one more important and most used functionality i.e. paging in sencha touch List.", CreationDate = DateTime.Now, Category = listCategory.Find(m => m.Name.Equals("Programming")), Tags = listTag.Where(x => x.Name.Equals("Sencha Touch") || x.Name.Equals("Asp.Net")).ToList() },
                new Post { Title = "CRUD Operation using Sencha Touch and ASP.Net MVC Web API", Body = "CRUD Operation using Sencha Touch and ASP.Net MVC Web API In this article I am going to explain and demonstrate how to create", CreationDate = DateTime.Now, Category = listCategory.Find(m => m.Name.Equals("Programming")), Tags = listTag.Where(x => x.Name.Equals("Sencha Touch") || x.Name.Equals("Asp.Net") || x.Name.Equals("MVC") || x.Name.Equals("Csharp")).ToList() },
                new Post { Title = "Union Example in SQL Server", Body = "In this article I am going to explain a use of union operator in SQL Server Database with a real life scenario and example. The UNION operator is used to combine the result-set of two or more SELECT statements.", CreationDate = DateTime.Now, Category = listCategory.Find(m => m.Name.Equals("Database")),Tags = listTag.Where(x => x.Name.Equals("SqlServer") || x.Name.Equals("Oracle")).ToList() },
                new Post { Title = "Pivot with Dynamic columns in SQL Server", Body = "Pivot with Dynamic columns in SQL Server In this article I will present how we can write a Dynamic PIVOT.", CreationDate = DateTime.Now, Category = listCategory.Find(m => m.Name.Equals("Database")), Tags = listTag.Where(x => x.Name.Equals("SqlServer") || x.Name.Equals("Oracle")).ToList() },
            };

            listCategory.ForEach(m =>
            {
                context.Category.Add(m);
            });
            context.SaveChanges();

            listTag.ForEach(m =>
            {
                context.Tag.Add(m);
            });
            context.SaveChanges();

            listPost.ForEach(m =>
            {
                context.Post.Add(m);
            });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}