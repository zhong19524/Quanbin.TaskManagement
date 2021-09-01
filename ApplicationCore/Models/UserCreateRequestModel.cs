using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class UserCreateRequestModel
    {
        [Required(ErrorMessage = "Email cannot be empty")]
        [EmailAddress(ErrorMessage = "Email should be in right format")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Password must be at least 8 characters long ", MinimumLength = 8)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage =
            "Password Should have minimum 8 with at least one upper, lower, number and special character")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        [StringLength(50)]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Mobileno cannot be empty")]
        [StringLength(50)]
        public string Mobileno { get; set; }

    }
}
