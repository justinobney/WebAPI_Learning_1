namespace WebAPI_Learning_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_FixCreatedAt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "CreatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "CreatedAt");
        }
    }
}
