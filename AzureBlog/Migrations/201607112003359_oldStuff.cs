namespace AzureBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oldStuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ArticleId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ArticleId");
        }
    }
}
