namespace Grupp29.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LaTillIRoomList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoomLists", "ListCreator", c => c.String());
            AddColumn("dbo.RoomLists", "PlantContent", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoomLists", "PlantContent");
            DropColumn("dbo.RoomLists", "ListCreator");
        }
    }
}
