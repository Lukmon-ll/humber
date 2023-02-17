namespace MyPassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class localGovns : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.localGovns",
                c => new
                    {
                        localGovnId = c.Int(nullable: false, identity: true),
                        localGovnName = c.String(),
                    })
                .PrimaryKey(t => t.localGovnId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.localGovns");
        }
    }
}
