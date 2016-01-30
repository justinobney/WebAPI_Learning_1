namespace WebAPI_Learning_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_AddEntityTypeConfig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Users", new[] { "Email", "Username" }, unique: true, name: "IX_UserNameEmail");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", "IX_UserNameEmail");
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
        }
    }
}
