using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Model
{
    public class ResetPaswordVM
    {
        [Required(ErrorMessage = "This field is Requird")]
        [MinLength(6, ErrorMessage = "Min Lenght 6")]
        public string Password { get; set; }
        [Required(ErrorMessage = "This field is Requird")]
        [MinLength(6, ErrorMessage = "Min Lenght 6")]
        [Compare("Password", ErrorMessage = "Password Not match")]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }
    }
}
