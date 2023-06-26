namespace NaijaCA_Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimeupdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "LandedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "LandedDate", c => c.DateTime(nullable: false));
        }
    }
}
