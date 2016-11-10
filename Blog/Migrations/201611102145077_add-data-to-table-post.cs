namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatatotablepost : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Posts (Title,Description,CreationDate,CategoryID) VALUES ('FIFA','Najlepszy Draft Ever',2001-12-12,2)");

            Sql("INSERT INTO Posts (Title,Description,CreationDate,CategoryID) VALUES ('FIFA','Najlepszy Draft Ever',2001-12-12,3)");

            Sql("INSERT INTO Posts (Title,Description,CreationDate,CategoryID) VALUES ('FIFA','Najlepszy Draft Ever',2001-12-12,1)");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Posts WHERE PostID IN (1,2,3)");
        }
    }
}
