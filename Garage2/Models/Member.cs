using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime EntryDate { get; set; }

        // Relational property
        public virtual ICollection<ParkedVehicle> ParkedVehicles { get; set; }
    }

}