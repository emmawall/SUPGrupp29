namespace Grupp29.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LadeTillPlantCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlantCategories",
                c => new
                    {
                        PlantCategoryName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PlantCategoryName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PlantCategories");
        }
    }
}
