using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Controllers.Resources
{
    public class CarResource
    {
        public int Id { get; set; }
        
        public string Make { get; set; }
        
        public string Model { get; set; }
        
        public string CarClass { get; set; }
        
        public int YearOfIssue { get; set; }
        
        public string RegistrationNumber { get; set; }
    }
}
