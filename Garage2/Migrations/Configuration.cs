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
            try
            {
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
                      TimeStamp = DateTime.Now
                  },
                  new ParkedVehicle
                  {
                      VehicleType = ParkedVehicle.VehicleTypeEnum.Car,
                      Brand = ParkedVehicle.BrandEnum.BMW,
                      Color = ParkedVehicle.ColorEnum.Red,
                      Model = ParkedVehicle.ModelEnum.Sedan,
                      RegNo = "ABC124",
                      NoWheels = 4,
                      TimeStamp = DateTime.Now
                  },
                  new ParkedVehicle
                  {
                      VehicleType = ParkedVehicle.VehicleTypeEnum.Car,
                      Brand = ParkedVehicle.BrandEnum.Merzedes,
                      Color = ParkedVehicle.ColorEnum.White,
                      Model = ParkedVehicle.ModelEnum.Sedan,
                      RegNo = "ABC125",
                      NoWheels = 4,
                      TimeStamp = DateTime.Now
                  },
                  new ParkedVehicle
                  {
                      VehicleType = ParkedVehicle.VehicleTypeEnum.Car,
                      Brand = ParkedVehicle.BrandEnum.Tesla,
                      Color = ParkedVehicle.ColorEnum.Green,
                      Model = ParkedVehicle.ModelEnum.Sedan,
                      RegNo = "ABC126",
                      NoWheels = 4,
                      TimeStamp = DateTime.Now
                  },
                  new ParkedVehicle
                  {
                      VehicleType = ParkedVehicle.VehicleTypeEnum.Bus,
                      Brand = ParkedVehicle.BrandEnum.Merzedes,
                      Color = ParkedVehicle.ColorEnum.Yellow,
                      RegNo = "ABC127",
                      NoWheels = 6,
                      TimeStamp = DateTime.Now
                  }
                );
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
