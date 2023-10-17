using company.DAL.Repository.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.DAL.Extend
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsAgree { get; set; }
        public string? PhotoCV { get; set; } 
        public string? PhotoName { get; set; } 

    }
}
