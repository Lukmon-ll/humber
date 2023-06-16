namespace NaijaCA_Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class memberstablecreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        LandedDate = c.DateTime(nullable: false),
                        FavouriteQuote = c.String(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.MemberID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Members");
        }
    }
}
