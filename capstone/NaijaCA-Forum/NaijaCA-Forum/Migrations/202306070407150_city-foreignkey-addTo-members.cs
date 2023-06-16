namespace NaijaCA_Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cityforeignkeyaddTomembers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "CityID", c => c.Int(nullable: false));
            CreateIndex("dbo.Members", "CityID");
            AddForeignKey("dbo.Members", "CityID", "dbo.Cities", "CityID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "CityID", "dbo.Cities");
            DropIndex("dbo.Members", new[] { "CityID" });
            DropColumn("dbo.Members", "CityID");
        }
    }
}
