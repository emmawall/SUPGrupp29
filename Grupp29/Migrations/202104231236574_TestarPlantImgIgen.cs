namespace Grupp29.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestarPlantImgIgen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlantLists", "PlantImg", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlantLists", "PlantImg");
        }
    }
}
