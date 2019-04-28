using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Core.Models
{
    public class ViewOrder
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string UserFirstName { get; set; }

        public int CarId { get; set; }
        public string CarMake { get; set; }

        public string CarRegistrationNumber { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
    }
}
