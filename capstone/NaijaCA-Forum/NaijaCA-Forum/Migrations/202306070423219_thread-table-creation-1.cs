namespace NaijaCA_Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class threadtablecreation1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        ThreadID = c.Int(nullable: false, identity: true),
                        MemberID = c.Int(nullable: false),
                        ThreadComment = c.String(),
                    })
                .PrimaryKey(t => t.ThreadID)
                .ForeignKey("dbo.Members", t => t.MemberID, cascadeDelete: true)
                .Index(t => t.MemberID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Threads", "MemberID", "dbo.Members");
            DropIndex("dbo.Threads", new[] { "MemberID" });
            DropTable("dbo.Threads");
        }
    }
}
