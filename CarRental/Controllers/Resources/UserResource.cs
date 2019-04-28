using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Controllers.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        
        public string LastName { get; set; }
        
        public string FirstName { get; set; }

        public DateTime BirthDate { get; set; }
        
        public string DriveLicenseNumber { get; set; }
    }
}
