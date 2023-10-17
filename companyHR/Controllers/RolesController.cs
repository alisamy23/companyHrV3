using company.BL.Model;
using company.DAL.Extend;
using company.DAL.Repository.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using AutoMapper;
using System.Data;

namespace companyHR.Controllers
{
    [Authorize]

    public class RolesController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplictionRoles> roleManager;
        private readonly IMapper mapper;

        public RolesController(UserManager<ApplicationUser> userManager,RoleManager<ApplictionRoles> roleManager, IMapper mapper) 
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
        }    
        public IActionResult  Index()
        {
            IEnumerable<ApplictionRoles> result =  roleManager.Roles;
            var data = mapper.Map<IEnumerable<ApplictionRolesVm>>(result);

            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public  async Task<IActionResult> Create(ApplictionRolesVm identityRole)
        {
            try
            {


                return await CreateRole(identityRole);
            }
            catch
            {
                return View(identityRole);

            }

        }

        private async Task<IActionResult> CreateRole(ApplictionRolesVm identityRole)
        {


            if (ModelState.IsValid)
            {
                var role = new ApplictionRoles()
                {
                    Name = identityRole.Name,
                    NormalizedName = identityRole.Name.ToLower(),
                };






                var resule = await roleManager.CreateAsync(role);
                if (resule.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in resule.Errors)
                    {
                        ModelState.AddModelError("", item.Description);

                    }
                    return View(identityRole);

                }
            }
            ModelState.AddModelError("", "Role Name is requird");
            return View(identityRole);
        }
        #region EditRole
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {

            ApplictionRoles role = await roleManager.FindByIdAsync(id);
            var data = mapper.Map<ApplictionRolesVm>(role);

            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ApplictionRolesVm identityRole)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<ApplictionRoles> (identityRole);

                    return await EditRole(data);

                }
                else
                {
                    return View(identityRole);

                }

            }
            catch (Exception ex)
            {
                return View(identityRole);
            }
        }

        private async Task<IActionResult> EditRole(IdentityRole identityRole)
        {
            var role = await roleManager.FindByIdAsync(identityRole.Id);
            role.Name = identityRole.Name;
            role.NormalizedName = identityRole.Name.ToUpper();
            var result = await roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(identityRole);
            }
        }
        #endregion

        #region DeleteRole
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {



            ApplictionRoles role = await roleManager.FindByIdAsync(id);
            var data = mapper.Map<ApplictionRolesVm>(role);

            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ApplictionRolesVm identityRole)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<ApplictionRoles>(identityRole);

                    return await DeleteRole(data);

                }
                else
                {
                    return View(identityRole);

                }

            }
            catch (Exception ex)
            {
                return View(identityRole);
            }
        }
        private async Task<IActionResult> DeleteRole(ApplictionRoles identityRole)
        {
            ApplictionRoles role = await roleManager.FindByIdAsync(identityRole.Id);
            var result = await roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var data = mapper.Map<ApplictionRolesVm>(identityRole);

                return View(data);
            }
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            ApplictionRoles role = await roleManager.FindByIdAsync(id);
            var data = mapper.Map<ApplictionRolesVm>(role);

            return View(data);
        }


    }
}
 