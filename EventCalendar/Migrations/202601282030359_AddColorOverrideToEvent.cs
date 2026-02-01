namespace EventCalendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColorOverrideToEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "ColorOvveride", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "ColorOvveride");
        }
    }
}
