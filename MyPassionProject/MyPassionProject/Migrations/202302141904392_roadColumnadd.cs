namespace MyPassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roadColumnadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.roads", "streetName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.roads", "streetName");
        }
    }
}
