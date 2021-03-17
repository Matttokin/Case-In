namespace Case_In.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Offices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOffice = c.String(),
                        DescriptionOffice = c.String(),
                        AddressOffice = c.String(),
                        AddressOfficeOnMap = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OfficePlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OfficeId = c.Int(nullable: false),
                        imgLink = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Offices", t => t.OfficeId, cascadeDelete: true)
                .Index(t => t.OfficeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OfficePlans", "OfficeId", "dbo.Offices");
            DropIndex("dbo.OfficePlans", new[] { "OfficeId" });
            DropTable("dbo.OfficePlans");
            DropTable("dbo.Offices");
        }
    }
}
