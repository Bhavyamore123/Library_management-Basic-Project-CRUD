using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Library_Model.Models
{
    public class Login_Model
    {
        public int Login_Id { get; set; }
        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Login_Email { get; set; }
        [Required(ErrorMessage = "Please enter your password.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Login_Password { get; set; }
        public string Login_Username { get; set; }

    }
}
