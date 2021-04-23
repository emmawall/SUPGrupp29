namespace Grupp29.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class laTillListId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoomLists", "listId_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.RoomLists", "listId_Id");
            AddForeignKey("dbo.RoomLists", "listId_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoomLists", "listId_Id", "dbo.AspNetUsers");
            DropIndex("dbo.RoomLists", new[] { "listId_Id" });
            DropColumn("dbo.RoomLists", "listId_Id");
        }
    }
}
