namespace Garage2.Migrations
{
    using Garage2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage2.Models.Garage2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Garage2.Models.Garage2Context";
        }

        protected override void Seed(Models.Garage2Context dbContext)
        {
            Console.WriteLine("RUNNNING SEED METHOD RBB...");

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            dbContext.ParkedVehicles.AddOrUpdate(
              p => p.RegNo,
              new ParkedVehicle
              {
                  VehicleType = ParkedVehicle.VehicleTypeEnum.Car,
                  Brand = ParkedVehicle.BrandEnum.Audi,
                  Color = ParkedVehicle.ColorEnum.Black,
                  Model = ParkedVehicle.ModelEnum.CrossOver,
                  RegNo = "ABC123",
                  NoWheels = 4,
                  CheckInTime = DateTime.Now,
                  CheckOutTime = DateTime.Now
              },
            new ParkedVehicle
            {
                VehicleType = ParkedVehicle.VehicleTypeEnum.Car,
                Brand = ParkedVehicle.BrandEnum.BMW,
                Color = ParkedVehicle.ColorEnum.Red,
                Model = ParkedVehicle.ModelEnum.Sedan,
                RegNo = "ABC124",
                NoWheels = 4,
                CheckInTime = DateTime.Now,
                CheckOutTime = DateTime.Now
            },
            new ParkedVehicle
            {
                VehicleType = ParkedVehicle.VehicleTypeEnum.Car,
                Brand = ParkedVehicle.BrandEnum.Merzedes,
                Color = ParkedVehicle.ColorEnum.White,
                Model = ParkedVehicle.ModelEnum.Sedan,
                RegNo = "ABC125",
                NoWheels = 4,
                CheckInTime = DateTime.Now,
                CheckOutTime = DateTime.Now
            },
            new ParkedVehicle
            {
                VehicleType = ParkedVehicle.VehicleTypeEnum.Car,
                Brand = ParkedVehicle.BrandEnum.Tesla,
                Color = ParkedVehicle.ColorEnum.Green,
                Model = ParkedVehicle.ModelEnum.Sedan,
                RegNo = "ABC126",
                NoWheels = 4,
                CheckInTime = DateTime.Now,
                CheckOutTime = DateTime.Now
            },
            new ParkedVehicle
            {
                VehicleType = ParkedVehicle.VehicleTypeEnum.Bus,
                Brand = ParkedVehicle.BrandEnum.Merzedes,
                Color = ParkedVehicle.ColorEnum.Yellow,
                Model = ParkedVehicle.ModelEnum.Sport,
                RegNo = "ABC127",
                NoWheels = 6,
                CheckInTime = DateTime.Now,
                CheckOutTime = DateTime.Now
            }
            );
        }
    }
}
