namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetimestampsfelds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParkedVehicles", "CheckInTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.ParkedVehicles", "CheckOutTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.ParkedVehicles", "TimeStamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParkedVehicles", "TimeStamp", c => c.DateTime(nullable: false));
            DropColumn("dbo.ParkedVehicles", "CheckOutTime");
            DropColumn("dbo.ParkedVehicles", "CheckInTime");
        }
    }
}
