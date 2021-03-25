namespace Grupp29.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "listName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "listName");
        }
    }
}
