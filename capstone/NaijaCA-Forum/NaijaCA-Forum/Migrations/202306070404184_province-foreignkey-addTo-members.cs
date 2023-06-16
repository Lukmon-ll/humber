namespace NaijaCA_Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class provinceforeignkeyaddTomembers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "ProvinceID", c => c.Int(nullable: false));
            CreateIndex("dbo.Members", "ProvinceID");
            AddForeignKey("dbo.Members", "ProvinceID", "dbo.Provinces", "ProvinceID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "ProvinceID", "dbo.Provinces");
            DropIndex("dbo.Members", new[] { "ProvinceID" });
            DropColumn("dbo.Members", "ProvinceID");
        }
    }
}
