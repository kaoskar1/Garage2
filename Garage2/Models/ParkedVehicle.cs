using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class ParkedVehicle
    {
        public enum VehicleTypeEnum { Car = 1, Bus = 2, Motorcycle = 3 }
        public enum BrandEnum { Audi = 1, BMW = 2, Merzedes = 3, Saab = 4, Tesla = 5, Volvo = 6 }
        public enum ColorEnum { Green = 1, White = 2, Yellow = 3, Black = 4, Brown = 5, Red = 6, Blue = 7 }
        public enum ModelEnum { Suv = 1, Sport = 2, CrossOver = 3, Sedan = 4 }

        public int Id { get; set; }

        [Required]
        [Range(1, 3, ErrorMessage = "Vehicle Type is required")]
        public VehicleTypeEnum VehicleType { get; set; }

        [Required]
        [Range(1, 6, ErrorMessage = "Brand is required")]
        public BrandEnum Brand { get; set; }

        [Range(1, 4, ErrorMessage = "Please select a car model")]
        public ModelEnum Model { get; set; }

        public ColorEnum Color { get; set; }

        public string RegNo { get; set; }

        public int NoWheels { get; set; }

        public DateTime CheckInTime { get; set; }
        //public DateTime CheckOutTime { get; set}
    }

    //    public class Parkingtime
    //    {

    //    }
    //        public class ParkingTimeModel { 

    //        public List<Parkingtime>  TimeParked{ get; set; }



    //}


}