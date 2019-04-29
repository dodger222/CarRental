using CarRental.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Core.Models
{
    public class OrderQuery : IQueryObject
    {
        public string UserFirstName { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string StartDate { get; set; }
        public string FinalDate { get; set; }

        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
    }
}
