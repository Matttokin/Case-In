namespace Case_In.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeTasks", "NameTask", c => c.String());
            AlterColumn("dbo.EmployeeTasks", "DateFinish", c => c.DateTime());
            DropColumn("dbo.EmployeeTasks", "NameTast");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeTasks", "NameTast", c => c.String());
            AlterColumn("dbo.EmployeeTasks", "DateFinish", c => c.DateTime(nullable: false));
            DropColumn("dbo.EmployeeTasks", "NameTask");
        }
    }
}
