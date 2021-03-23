namespace Grupp29.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoomList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoomLists",
                c => new
                    {
                        listName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.listName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RoomLists");
        }
    }
}
