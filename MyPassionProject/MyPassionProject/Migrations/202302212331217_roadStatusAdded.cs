namespace MyPassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roadStatusAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.roads", "roadStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.roads", "roadStatus");
        }
    }
}
