namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TagID);
            
            CreateTable(
                "dbo.TagPosts",
                c => new
                    {
                        Tag_TagID = c.Int(nullable: false),
                        Post_PostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagID, t.Post_PostID })
                .ForeignKey("dbo.Tags", t => t.Tag_TagID, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.Post_PostID, cascadeDelete: true)
                .Index(t => t.Tag_TagID)
                .Index(t => t.Post_PostID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagPosts", "Post_PostID", "dbo.Posts");
            DropForeignKey("dbo.TagPosts", "Tag_TagID", "dbo.Tags");
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.Categories");
            DropIndex("dbo.TagPosts", new[] { "Post_PostID" });
            DropIndex("dbo.TagPosts", new[] { "Tag_TagID" });
            DropIndex("dbo.Posts", new[] { "CategoryID" });
            DropTable("dbo.TagPosts");
            DropTable("dbo.Tags");
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
