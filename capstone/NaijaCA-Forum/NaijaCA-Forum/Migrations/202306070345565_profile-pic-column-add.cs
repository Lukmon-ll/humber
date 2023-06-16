namespace NaijaCA_Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class profilepiccolumnadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "ProfilePic", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "ProfilePic");
        }
    }
}
