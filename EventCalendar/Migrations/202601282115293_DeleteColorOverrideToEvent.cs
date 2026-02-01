namespace EventCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteColorOverrideToEvent : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "ColorOvveride");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "ColorOvveride", c => c.String());
        }
    }
}
