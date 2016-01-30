namespace WebAPI_Learning_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_FixDates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "ModifiedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "ModifiedAt", c => c.DateTime(nullable: false));
        }
    }
}
