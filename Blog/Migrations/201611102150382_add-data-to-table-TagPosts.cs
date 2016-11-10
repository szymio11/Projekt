namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatatotableTagPosts : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TagPosts (Tag_TagID,Post_PostID) VALUES (1,2)");

            Sql("INSERT INTO TagPosts (Tag_TagID,Post_PostID) VALUES (2,3)");

            Sql("INSERT INTO TagPosts (Tag_TagID,Post_PostID) VALUES (3,4)");
        }

        public override void Down()
        {
            Sql("DELETE FROM TagPosts WHERE Tag_TagID IN (1,2,3)");
        }
    }
}
