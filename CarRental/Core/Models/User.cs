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

        [RegularExpression(@"^[A-Z]{1}[a-z]+$", ErrorMessage = "The 'Last Name' field must have only letters and begin with a capital letter.")]
        [StringLength(255)]
        [Required]
        public string LastName { get; set; }

        [RegularExpression(@"^[A-Z]{1}[a-z]+$", ErrorMessage = "The 'First Name' field must have only letters and begin with a capital letter.")]
        [StringLength(255)]
        [Required]
        public string FirstName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(255)]
        [RegularExpression(@"^\d{1}[A-Z]{2}\s{1}\d{6}$", ErrorMessage = "Формат номера ВУ: 1AA 111111")]
        public string DriveLicenseNumber { get; set; }
    }
}
