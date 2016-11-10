using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class PostDbContext : DbContext
    {
        public PostDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new PostDbContextInitializer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // overriding pluralize convention
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // configuring many-to-may relationship between Post and Tag
            modelBuilder.Entity<Post>().HasMany<Tag>(s => s.Tags).WithMany(c => c.Posts).Map(m =>
            {
                m.MapLeftKey("PostID");
                m.MapRightKey("TagID");
                m.ToTable("PostTagMap");
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Post> Post { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
