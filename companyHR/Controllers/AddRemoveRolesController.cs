using company.BL.Model;
using company.DAL.Extend;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace companyHR.Controllers
{
    [Authorize]

    public class AddRemoveRolesController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplictionRoles> roleManager;

        public AddRemoveRolesController(UserManager<ApplicationUser> userManager, RoleManager<ApplictionRoles> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }


        public async Task<IActionResult> Index()
        {
            var result = roleManager.Roles;
            List<UsersRolesVm> usersRoles = new List<UsersRolesVm>();
            foreach (var role in result)
            {

                var users = await userManager.GetUsersInRoleAsync(role.Name);
                if (users.Count != 0)
                {
                    foreach (var user in users)
                    {
                        UsersRolesVm usersRolesVm = new UsersRolesVm();
                        usersRolesVm.UserId = user.Id;
                        usersRolesVm.UserNAME = user.UserName;
                        usersRolesVm.RoleID = role.Id;
                        usersRolesVm.RoleName = role.Name;
                        usersRoles.Add(usersRolesVm);
                    }

                }

            }
            return View(usersRoles);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsersRolesVm usersRoles)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByIdAsync(usersRoles.UserId);
                    var result = await userManager.AddToRoleAsync(user, usersRoles.RoleName);
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
                        return View(usersRoles);
                    }
                }
                else
                {
                    return View(usersRoles);

                }

            }
            catch (Exception ex)
            {
                return View(usersRoles);

            }
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string UserId, string RoleID)
        {
            try
            {
                var role = await roleManager.FindByIdAsync(RoleID);
                var user = await userManager.FindByIdAsync(UserId);
                UsersRolesVm usersRoles = new UsersRolesVm()

                {
                    RoleName = role.Name,
                    RoleID = role.Id,
                    UserId = user.Id,
                    UserNAME = user.UserName

                };

                if (ModelState.IsValid)
                {
                    return View(usersRoles);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            catch
            {
                return RedirectToAction("Index");

            }

        }



        [HttpPost]
        public async Task<IActionResult> Delete(UsersRolesVm usersRoles)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    ApplicationUser user = await userManager.FindByIdAsync(usersRoles.UserId);
                    var result = await userManager.RemoveFromRoleAsync(user, usersRoles.RoleName);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(usersRoles);
                    }
                }
                else
                {
                    return View(usersRoles);

                }
            }
            catch
            {
                ModelState.AddModelError("", "Dont Remove");
                return View(usersRoles);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Details(string UserId, string RoleID)
        {
            try
            {
                var role = await roleManager.FindByIdAsync(RoleID);
                var user = await userManager.FindByIdAsync(UserId);
                UsersRolesVm usersRoles = new UsersRolesVm()

                {
                    RoleName = role.Name,
                    RoleID = role.Id,
                    UserId = user.Id,
                    UserNAME = user.UserName

                };

                if (ModelState.IsValid)
                {
                    return View(usersRoles);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            catch
            {
                return RedirectToAction("Index");

            }

        }
    }
}
