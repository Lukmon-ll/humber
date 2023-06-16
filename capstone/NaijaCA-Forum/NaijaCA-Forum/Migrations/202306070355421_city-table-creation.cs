namespace NaijaCA_Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class citytablecreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.CityID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cities");
        }
    }
}
