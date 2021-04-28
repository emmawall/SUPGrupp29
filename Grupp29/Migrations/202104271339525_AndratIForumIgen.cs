namespace Grupp29.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AndratIForumIgen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Fora", "DateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fora", "DateTime", c => c.String());
        }
    }
}
