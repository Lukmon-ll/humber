namespace NaijaCA_Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class titleaddedthread : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Threads", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Threads", "Title");
        }
    }
}
