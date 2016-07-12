namespace AzureBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class segmentAuthors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArticleSegments", "ArticleSegmentAuthor", c => c.String());
            AddColumn("dbo.ArticleSegments", "ArticleSegmentEmail", c => c.String());
            AddColumn("dbo.ArticleSegments", "ArticleSegmentWebsite", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ArticleSegments", "ArticleSegmentWebsite");
            DropColumn("dbo.ArticleSegments", "ArticleSegmentEmail");
            DropColumn("dbo.ArticleSegments", "ArticleSegmentAuthor");
        }
    }
}
