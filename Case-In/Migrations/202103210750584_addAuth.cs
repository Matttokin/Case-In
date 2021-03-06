namespace Case_In.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAuth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Login", c => c.String());
            AddColumn("dbo.Users", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "Login");
        }
    }
}
