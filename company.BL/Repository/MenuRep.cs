using Azure;
using company.BL.Interface;
using company.BL.Model;
using company.DAL.Entity;
using company.DAL.Extend;
using company.DAL.Repository.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Repository
{
    public class MenuRep : IMenuRep
    {
        private readonly CompanyContext context;



        public MenuRep(CompanyContext context)
        {
            this.context = context;

        }
        public  IEnumerable<Menu> GetMenu(List<string> array)

        {
            try
            {
                var data = context.RolesPages.Include("Page").Include("role").Where(o => array.ToArray().Contains(o.roleID)).Select(o=>new Menu
                {
                    pageNAme=o.Page.PageName,
                    pageAction=o.Page.PageAction,
                    pageControl=o.Page.PageControl,
                    pageid=o.Page.Id,
                    parentId=o.Page.ParentiD

                }).Distinct();


                return data;
            }
            catch
            {
                return new List<Menu>();
            }
          
        }
        public  IEnumerable<Pages> GetMenuWithoueHeder(string userName,List<string>  rolesName)
        {
            try
            {

                

                
                var application = context.RolesPages.Include("Page").Include("role").Where(o=> rolesName.Contains(o.role.Name)).Select(o=>o.Page).Distinct();

                //IList<string> roles = await userManager.GetRolesAsync(application);
                //List<string> rolesid = roleManager.Roles.Where(o => roles.Contains(o.Name)).Select(o => o.Id).ToList();






                //var data = context.RolesPages.Include("Page").Include("role").Where(o =>o.Page.PageControl!=null && rolesid.ToArray().Contains(o.roleID)).Select(o=>o.Page.Path).Distinct();


                return application;
            }
            catch
            {
                return new List<Pages>();
            }
          
        }
    }
}
