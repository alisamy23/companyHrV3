using company.DAL.Repository.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.DAL.Extend
{
    public class ApplictionRoles:IdentityRole
    {
        public virtual ICollection<RolesPage> RolesPages { get; set; } = new List<RolesPage>();

    }
}
