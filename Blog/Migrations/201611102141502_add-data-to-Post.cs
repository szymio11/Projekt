namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatatoPost : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Name) VALUES ('FIFA 16')");
            Sql("INSERT INTO Categories (Name) VALUES ('FIFA 17')");
            Sql("INSERT INTO Categories (Name) VALUES ('FIFA 15')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Categories WHERE CategoryID IN (1,2,3)");
        }
    }
}
