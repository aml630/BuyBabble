namespace AzureBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class voteOnceChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Voters",
                c => new
                    {
                        VoterId = c.Int(nullable: false, identity: true),
                        VoterIPAddress = c.String(),
                        ArticleSegmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VoterId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Voters");
        }
    }
}
