namespace Grupp29.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class laTillIdPaRoomlist : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.RoomLists");
            AddColumn("dbo.RoomLists", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.RoomLists", "listName", c => c.String());
            AddPrimaryKey("dbo.RoomLists", "id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.RoomLists");
            AlterColumn("dbo.RoomLists", "listName", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.RoomLists", "id");
            AddPrimaryKey("dbo.RoomLists", "listName");
        }
    }
}
