using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Model
{
    public class ApplicationUserVm
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
              
        public string? PhotoName { get; set; }

        public IFormFile? Photo { get; set; }
    }
}
