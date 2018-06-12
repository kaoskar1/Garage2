using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class ParkedVehicle
    {
        public enum BrandEnum { Audi = 1, BMW = 2, Merzedes = 3, Saab = 4, Tesla = 5, Volvo = 6 }
        public enum ColorEnum { Green = 1, White = 2, Yellow = 3, Black = 4, Brown = 5, Red = 6, Blue = 7 }
        public enum ModelEnum { Suv = 1, Sport = 2, CrossOver = 3, Sedan = 4 }

        public int Id { get; set; }

        [Required]
        [Range(1, 6, ErrorMessage = "Brand is required")]
        public BrandEnum Brand { get; set; }

        [Range(1, 4, ErrorMessage = "Please select a car model")]
        public ModelEnum Model { get; set; }

        public ColorEnum Color { get; set; }

        [Display(Name = "Registration Number")]
        public string RegNo { get; set; }

        [Display(Name = "Number of Wheels")]
        public int NoWheels { get; set; }

        [Display(Name = "Checkin Time")]
        public DateTime CheckInTime { get; set; }

        // Relational properties
        public int VehicleTypeId { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public int MemberId { get; set; }
        public virtual Member Member { get; set; }
    }


}