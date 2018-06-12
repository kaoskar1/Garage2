namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMember : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(),
                    LastName = c.String(),
                    PhoneNumber = c.String(),
                    EntryDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.ParkedVehicles", "Member_Id", c => c.Int());
            CreateIndex("dbo.ParkedVehicles", "Member_Id");
            AddForeignKey("dbo.ParkedVehicles", "Member_Id", "dbo.Members", "Id");

            DropColumn("dbo.ParkedVehicles", "VehicleType");
        }

        public override void Down()
        {
            AddColumn("dbo.ParkedVehicles", "VehicleType", c => c.Int(nullable: false));
            DropForeignKey("dbo.ParkedVehicles", "Member_Id", "dbo.Members");
            DropIndex("dbo.ParkedVehicles", new[] { "Member_Id" });
            DropColumn("dbo.ParkedVehicles", "Member_Id");
            DropTable("dbo.Members");
        }
    }
}
