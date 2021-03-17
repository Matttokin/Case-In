namespace Case_In.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserAndCulture : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CultureImgs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CultureId = c.Int(nullable: false),
                        ImgLink = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cultures", t => t.CultureId, cascadeDelete: true)
                .Index(t => t.CultureId);
            
            CreateTable(
                "dbo.Cultures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataRow = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        NameTast = c.String(),
                        DateStart = c.DateTime(nullable: false),
                        DateFinish = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameUser = c.String(),
                        DateBirth = c.DateTime(nullable: false),
                        DateStartWork = c.DateTime(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NamePost = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeTasks", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "PostId", "dbo.Posts");
            DropForeignKey("dbo.CultureImgs", "CultureId", "dbo.Cultures");
            DropIndex("dbo.Users", new[] { "PostId" });
            DropIndex("dbo.EmployeeTasks", new[] { "UserId" });
            DropIndex("dbo.CultureImgs", new[] { "CultureId" });
            DropTable("dbo.Posts");
            DropTable("dbo.Users");
            DropTable("dbo.EmployeeTasks");
            DropTable("dbo.Cultures");
            DropTable("dbo.CultureImgs");
        }
    }
}
