namespace Grupp29.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlantRoomIgen : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlantRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        plantlist_PlantId = c.Int(),
                        roomlist_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlantLists", t => t.plantlist_PlantId)
                .ForeignKey("dbo.RoomLists", t => t.roomlist_id)
                .Index(t => t.plantlist_PlantId)
                .Index(t => t.roomlist_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlantRooms", "roomlist_id", "dbo.RoomLists");
            DropForeignKey("dbo.PlantRooms", "plantlist_PlantId", "dbo.PlantLists");
            DropIndex("dbo.PlantRooms", new[] { "roomlist_id" });
            DropIndex("dbo.PlantRooms", new[] { "plantlist_PlantId" });
            DropTable("dbo.PlantRooms");
        }
    }
}
