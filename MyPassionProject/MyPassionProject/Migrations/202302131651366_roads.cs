namespace MyPassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roads : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.roads",
                c => new
                    {
                        roadId = c.Int(nullable: false, identity: true),
                        posterFirstName = c.String(),
                        posterLastName = c.String(),
                    })
                .PrimaryKey(t => t.roadId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.roads");
        }
    }
}
