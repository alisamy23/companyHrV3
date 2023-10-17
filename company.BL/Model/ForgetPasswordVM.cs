using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Model
{
    public class ForgetPasswordVM
    {
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [Required(ErrorMessage = "This field is Requird")]
        public string Email { get; set; }
    }
}
