namespace Mountains_Code_First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 2, fixedLength: true, unicode: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.Mountains",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Peaks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Elevation = c.Int(nullable: false),
                        Mountain_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mountains", t => t.Mountain_Id)
                .Index(t => t.Mountain_Id);
            
            CreateTable(
                "dbo.MountainCountries",
                c => new
                    {
                        Mountain_Id = c.Int(nullable: false),
                        Country_Code = c.String(nullable: false, maxLength: 2, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => new { t.Mountain_Id, t.Country_Code })
                .ForeignKey("dbo.Mountains", t => t.Mountain_Id, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.Country_Code, cascadeDelete: true)
                .Index(t => t.Mountain_Id)
                .Index(t => t.Country_Code);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Peaks", "Mountain_Id", "dbo.Mountains");
            DropForeignKey("dbo.MountainCountries", "Country_Code", "dbo.Countries");
            DropForeignKey("dbo.MountainCountries", "Mountain_Id", "dbo.Mountains");
            DropIndex("dbo.MountainCountries", new[] { "Country_Code" });
            DropIndex("dbo.MountainCountries", new[] { "Mountain_Id" });
            DropIndex("dbo.Peaks", new[] { "Mountain_Id" });
            DropTable("dbo.MountainCountries");
            DropTable("dbo.Peaks");
            DropTable("dbo.Mountains");
            DropTable("dbo.Countries");
        }
    }
}
