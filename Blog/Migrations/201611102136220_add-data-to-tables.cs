namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatatotables : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Tags (Name) VALUES ('FIFA 16')");
            Sql("INSERT INTO Tags (Name) VALUES ('FIFA 17')");
            Sql("INSERT INTO Tags (Name) VALUES ('FIFA ULTIMATE TEAM')");
            Sql("INSERT INTO Tags (Name) VALUES ('DRAFT')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Tags WHERE TagID IN (1,2,3,4)");
        }
    }
}
