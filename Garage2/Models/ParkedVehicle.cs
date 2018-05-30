using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class ParkedVehicle
    {
        public enum VehicleType { Car, Bus, Motorcycle }
        public String Color { get; set; }
        public int MyProperty { get; set; }
    }   
}