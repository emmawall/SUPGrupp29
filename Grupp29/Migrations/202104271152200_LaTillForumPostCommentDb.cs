namespace Grupp29.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LaTillForumPostCommentDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ForumPostComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        CommentText = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        ForumPostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ForumPostComments");
        }
    }
}
