using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Controllers.Resources
{
    public class FilterResource
    {
        public string UserFirstName { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
    }
}
