namespace Grupp29.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LaTillPlantCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlantLists", "PlantCategory", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlantLists", "PlantCategory");
        }
    }
}
