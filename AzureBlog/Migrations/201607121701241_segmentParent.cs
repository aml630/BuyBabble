namespace AzureBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class segmentParent : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "ArticleSegmentModel_ArticleSegmentId", newName: "ArticleSegment_ArticleSegmentId");
            RenameIndex(table: "dbo.Products", name: "IX_ArticleSegmentModel_ArticleSegmentId", newName: "IX_ArticleSegment_ArticleSegmentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Products", name: "IX_ArticleSegment_ArticleSegmentId", newName: "IX_ArticleSegmentModel_ArticleSegmentId");
            RenameColumn(table: "dbo.Products", name: "ArticleSegment_ArticleSegmentId", newName: "ArticleSegmentModel_ArticleSegmentId");
        }
    }
}
