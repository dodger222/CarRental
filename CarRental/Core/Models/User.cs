using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Core.Models
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(255)]
        public string DriveLicenseNumber { get; set; }
    }
}
