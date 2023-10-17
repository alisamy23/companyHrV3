using Azure;
using company.DAL.Extend;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.DAL.Repository.Models
{
    [Table("RolesPage")]
    public partial class RolesPage
    {
        [Key]
        public int Id { get; set; }
        [ StringLength(450)]
        public string roleID { get; set; } = null!;

        public int PageId { get; set; }

  

        [ForeignKey("PageId")]
        public virtual Pages Page { get; set; } = null!;

        [ForeignKey("roleID")]
        public virtual ApplictionRoles role { get; set; } = null!;


    }
}
