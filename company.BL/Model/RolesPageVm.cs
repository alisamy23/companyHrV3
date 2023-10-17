using company.DAL.Extend;
using company.DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Model
{
    public class RolesPageVm
    {

        public int Id { get; set; }
        public string roleID { get; set; } = null!;
        public int PageId { get; set; }
        public  Pages Page { get; set; } = null!;
        public  ApplictionRoles role { get; set; } = null!;
    }
}
