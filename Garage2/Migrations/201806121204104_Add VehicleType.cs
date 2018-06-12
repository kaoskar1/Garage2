namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehicleType : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Members",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            FirstName = c.String(),
            //            LastName = c.String(),
            //            PhoneNumber = c.String(),
            //            EntryDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            //AddColumn("dbo.ParkedVehicles", "Member_Id", c => c.Int());
            AddColumn("dbo.ParkedVehicles", "VehicleType_Id", c => c.Int());
            //CreateIndex("dbo.ParkedVehicles", "Member_Id");
            CreateIndex("dbo.ParkedVehicles", "VehicleType_Id");
            //AddForeignKey("dbo.ParkedVehicles", "Member_Id", "dbo.Members", "Id");
            AddForeignKey("dbo.ParkedVehicles", "VehicleType_Id", "dbo.VehicleTypes", "Id");
            //DropColumn("dbo.ParkedVehicles", "VehicleType");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.ParkedVehicles", "VehicleType", c => c.Int(nullable: false));
            DropForeignKey("dbo.ParkedVehicles", "VehicleType_Id", "dbo.VehicleTypes");
            //DropForeignKey("dbo.ParkedVehicles", "Member_Id", "dbo.Members");
            DropIndex("dbo.ParkedVehicles", new[] { "VehicleType_Id" });
            //DropIndex("dbo.ParkedVehicles", new[] { "Member_Id" });
            DropColumn("dbo.ParkedVehicles", "VehicleType_Id");
            //DropColumn("dbo.ParkedVehicles", "Member_Id");
            DropTable("dbo.VehicleTypes");
            //DropTable("dbo.Members");
        }
    }
}
