namespace Grupp29.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LaTillImgDesc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlantLists", "ImgDesc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlantLists", "ImgDesc");
        }
    }
}
