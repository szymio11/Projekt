namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validpost : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Posts", "Title", c => c.String());
            AlterColumn("dbo.Posts", "Description", c => c.String());
            AlterColumn("dbo.Tags", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tags", "Name", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Posts", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 60));
        }
    }
}
