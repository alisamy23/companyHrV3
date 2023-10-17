using company.BL.Model;
using company.DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Interface
{
    public interface IMenuRep
    {
        public IEnumerable<Menu> GetMenu(List<string> array);
        public IEnumerable<Pages> GetMenuWithoueHeder(string userName, List<string> roles);

    }
}
