using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Core.Models
{
    [Table("Cars")]
    public class Car
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[\D]+$", ErrorMessage = "The 'Make' field must have only letters/spaces and begin with a capital letter.")]
        [Required]
        [StringLength(255)]
        public string Make { get; set; }

        [Required]
        [StringLength(255)]
        public string Model { get; set; }

        [RegularExpression(@"^[ABCDESMJF]+[\D]+$", ErrorMessage = "The 'Car class' field must have only A B C D E F J M S.")]
        [Required]
        [StringLength(255)]
        public string CarClass { get; set; }

        [Required]
        [Range(1990, 2019, ErrorMessage = "The value of the 'Year of issue' field must be between 1990 and 2019.")]
        public int YearOfIssue { get; set; }

        [Required]
        [StringLength(255)]
        public string RegistrationNumber { get; set; }
    }
}
