namespace AzureBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class segmentPublished : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArticleSegments", "Published", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ArticleSegments", "Published");
        }
    }
}
