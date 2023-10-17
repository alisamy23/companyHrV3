using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Model
{

    public class UsersRolesVm
    {

        public string? RoleID { get; set; }
        [Required]

        public string? RoleName { get; set; }

        public string? UserNAME { get; set; }
        [Required]


        public string? UserId { get; set; }
    }
}
