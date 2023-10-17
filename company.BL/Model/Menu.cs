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
    public class Menu
    {

        public int Id { get; set; }
        public string? pageNAme { get; set; } = null!;
        public string? pageControl { get; set; }
        public string? pageAction { get; set; }
        public int pageid { get; set; }
        public int? parentId { get; set; }
        
      
    }
}
