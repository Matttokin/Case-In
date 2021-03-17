namespace Case_In.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegulationsDocs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameDocs = c.String(),
                        LinkDocs = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RegulationsDocs");
        }
    }
}
