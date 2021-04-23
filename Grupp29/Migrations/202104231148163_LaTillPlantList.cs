namespace Grupp29.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LaTillPlantList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlantLists",
                c => new
                    {
                        PlantId = c.Int(nullable: false, identity: true),
                        PlantName = c.String(),
                        Description = c.String(),
                        WaterNeed = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.PlantId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PlantLists");
        }
    }
}
