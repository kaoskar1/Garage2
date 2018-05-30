using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class ParkedVehicle
    {
        public enum VehicleTypeEnum { Car, Bus, Motorcycle }
        public enum BrandEnum { Audi, Volvo, Merzedes, Saab, BMW, Tesla }
        public enum ColorEnum { Green, White, Yellow, Black, Brown, Red, Blue }
        public enum ModelEnum { Suv, SPort, CrossOver, Sedan }

        public int Id { get; set; }
        public VehicleTypeEnum VehicleType { get; set; }
        public BrandEnum Brand { get; set; }
        public ModelEnum Model { get; set; }
        public ColorEnum Color { get; set; }
        public string RegNo { get; set; }
        public int NoWheels { get; set; }
    }
}