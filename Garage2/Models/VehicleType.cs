using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string Description { get; set; }

        // Relational property
        public virtual ICollection<ParkedVehicle> ParkedVehicles { get; set; }
    }
}