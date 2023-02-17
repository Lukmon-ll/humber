namespace MyPassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        companyID = c.Int(nullable: false, identity: true),
                        companyName = c.String(),
                    })
                .PrimaryKey(t => t.companyID);
            
            CreateTable(
                "dbo.Companyroads",
                c => new
                    {
                        Company_companyID = c.Int(nullable: false),
                        road_roadId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Company_companyID, t.road_roadId })
                .ForeignKey("dbo.Companies", t => t.Company_companyID, cascadeDelete: true)
                .ForeignKey("dbo.roads", t => t.road_roadId, cascadeDelete: true)
                .Index(t => t.Company_companyID)
                .Index(t => t.road_roadId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companyroads", "road_roadId", "dbo.roads");
            DropForeignKey("dbo.Companyroads", "Company_companyID", "dbo.Companies");
            DropIndex("dbo.Companyroads", new[] { "road_roadId" });
            DropIndex("dbo.Companyroads", new[] { "Company_companyID" });
            DropTable("dbo.Companyroads");
            DropTable("dbo.Companies");
        }
    }
}
