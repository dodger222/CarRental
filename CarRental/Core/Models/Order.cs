using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Core.Models
{
    [Table("Orders")]
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }

        [Required]
        [StringLength(255)]
        public string Comment { get; set; }

    }
}
