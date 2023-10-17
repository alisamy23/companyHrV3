using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Model
{
    public class RegistrationVM
    {
        [EmailAddress(ErrorMessage ="Invalid Email")]
        [Required (ErrorMessage ="This field is Requird")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is Requird")]
        [MinLength(6,ErrorMessage ="Min Lenght 6")]
        public string Password { get; set; }
        [Required(ErrorMessage = "This field is Requird")]
        [MinLength(6, ErrorMessage = "Min Lenght 6")]
        [Compare("Password",ErrorMessage ="Password Not match")]
        public string ConfirmPassword { get; set; }
        public bool IsAgree { get; set; }
    }
}
