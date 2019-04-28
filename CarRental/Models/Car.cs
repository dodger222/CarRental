using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    [Table("Cars")]
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Make { get; set; }

        [Required]
        [StringLength(255)]
        public string Model { get; set; }

        [Required]
        [StringLength(255)]
        public string CarClass { get; set; }

        [Required]
        [Range(1990, 2019)]
        public int YearOfIssue { get; set; }

        [Required]
        [StringLength(255)]
        public string RegistrationNumber { get; set; }
    }
}
