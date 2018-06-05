namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCheckInTime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ParkedVehicles", "CheckOutTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParkedVehicles", "CheckOutTime", c => c.DateTime(nullable: false));
        }
    }
}
