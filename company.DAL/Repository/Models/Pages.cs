using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.DAL.Repository.Models
{
    public class Pages
    {
        [Key]

        public int Id { get; set; }
        public int? ParentiD { get; set; }
        [Required]
        public string? PageName { get; set; }
        public string? PageControl { get; set; }
        public string? PageAction { get; set; }
        public string? Path { get; set; }

        [InverseProperty("Page")]
        public virtual ICollection<RolesPage> RolesPages { get; set; } = new List<RolesPage>();

    }
}
