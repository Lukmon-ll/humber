namespace MyPassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.roads", "roadLength", c => c.Int(nullable: false));
            AddColumn("dbo.roads", "roadImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.roads", "roadImage");
            DropColumn("dbo.roads", "roadLength");
        }
    }
}
