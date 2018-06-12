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
            var members = new[]
            {
                new Member { FirstName = "Kalle", LastName = "Anka", PhoneNumber = "08-34 93 49", EntryDate = DateTime.Now },
                new Member { FirstName = "Kajsa", LastName = "Anka", PhoneNumber = "08-34 93 42", EntryDate = DateTime.Now },
                new Member { FirstName = "Joakim", LastName = "von Anka", PhoneNumber = "08-32 93 49", EntryDate = DateTime.Now },
                new Member { FirstName = "Tjatte", LastName = "Anka", PhoneNumber = "08-34 93 39", EntryDate = DateTime.Now },
                new Member { FirstName = "Fnatte", LastName = "Anka", PhoneNumber = "08-34 93 89", EntryDate = DateTime.Now }
            };

            dbContext.Members.AddOrUpdate(
                m => new { m.FirstName, m.LastName },
                members
                );

            var vehicleTypes = new[] {
                new VehicleType { Description = "Car" },
                new VehicleType { Description = "Bus" },
                new VehicleType { Description = "Motorcycle" }
                };

            dbContext.VehicleTypes.AddOrUpdate(
            vt => vt.Description,
            vehicleTypes
            );

            // Make sure that the records are stored before adding ParkedVehicles!
            dbContext.SaveChanges();

            dbContext.ParkedVehicles.AddOrUpdate(
              p => p.RegNo,
              new ParkedVehicle
              {
                  VehicleType = vehicleTypes[0],
                  MemberId = members[0].Id,
                  Brand = ParkedVehicle.BrandEnum.Audi,
                  Color = ParkedVehicle.ColorEnum.Black,
                  Model = ParkedVehicle.ModelEnum.CrossOver,
                  RegNo = "ABC123",
                  NoWheels = 4,
                  CheckInTime = DateTime.Now
              },
            new ParkedVehicle
            {
                VehicleType = vehicleTypes[0],
                MemberId = members[4].Id,
                Brand = ParkedVehicle.BrandEnum.BMW,
                Color = ParkedVehicle.ColorEnum.Red,
                Model = ParkedVehicle.ModelEnum.Sedan,
                RegNo = "ABC124",
                NoWheels = 4,
                CheckInTime = DateTime.Now
            },
            new ParkedVehicle
            {
                VehicleType = vehicleTypes[0],
                MemberId = members[1].Id,
                Brand = ParkedVehicle.BrandEnum.Merzedes,
                Color = ParkedVehicle.ColorEnum.White,
                Model = ParkedVehicle.ModelEnum.Sedan,
                RegNo = "ABC125",
                NoWheels = 4,
                CheckInTime = DateTime.Now
            },
            new ParkedVehicle
            {
                VehicleType = vehicleTypes[0],
                MemberId = members[2].Id,
                Brand = ParkedVehicle.BrandEnum.Tesla,
                Color = ParkedVehicle.ColorEnum.Green,
                Model = ParkedVehicle.ModelEnum.Sedan,
                RegNo = "ABC126",
                NoWheels = 4,
                CheckInTime = DateTime.Now
            },
            new ParkedVehicle
            {
                VehicleType = vehicleTypes[1],
                MemberId = members[3].Id,
                Brand = ParkedVehicle.BrandEnum.Merzedes,
                Color = ParkedVehicle.ColorEnum.Yellow,
                Model = ParkedVehicle.ModelEnum.Sport,
                RegNo = "ABC127",
                NoWheels = 6,
                CheckInTime = DateTime.Now
            }
            );
        }
    }
}
