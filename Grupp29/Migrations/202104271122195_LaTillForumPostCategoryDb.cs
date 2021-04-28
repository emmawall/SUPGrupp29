namespace Grupp29.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LaTillForumPostCategoryDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ForumPostCategories",
                c => new
                    {
                        CategoryName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CategoryName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ForumPostCategories");
        }
    }
}
