using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class ParkedVehicle
    {
        public enum VehicleTypeEnum { Car, Bus, Motorcycle }
        public enum BrandEnum { Audi, Volov, Merzedes, Saab, BMW, Tesla }

        public int Id { get; set; }
        public VehicleTypeEnum VehicleType { get; set; }
        public BrandEnum Brand { get; set; }
        public string Color { get; set; }
        public string RegNo { get; set; }
        public string Model { get; set; }
        public int NoWheels { get; set; }
    }   
}