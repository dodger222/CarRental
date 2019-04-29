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

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int CarId { get; set; }
        public Car Car { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime FinalDate { get; set; }

        [Required]
        [StringLength(255)]
        public string Comment { get; set; }

    }
}
