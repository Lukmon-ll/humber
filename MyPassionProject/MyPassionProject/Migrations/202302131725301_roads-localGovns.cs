namespace MyPassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roadslocalGovns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.roads", "localGovnId", c => c.Int(nullable: false));
            CreateIndex("dbo.roads", "localGovnId");
            AddForeignKey("dbo.roads", "localGovnId", "dbo.localGovns", "localGovnId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.roads", "localGovnId", "dbo.localGovns");
            DropIndex("dbo.roads", new[] { "localGovnId" });
            DropColumn("dbo.roads", "localGovnId");
        }
    }
}
