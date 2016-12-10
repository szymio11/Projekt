namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addusertopost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Posts", "User_Id");
            AddForeignKey("dbo.Posts", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropColumn("dbo.Posts", "User_Id");
        }
    }
}
