using company.BL.Model;
using company.DAL.Extend;
using Demo.BL.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using System.Web.Mvc;
using AutoMapper;

namespace companyHR.Controllers
{
    [Authorize]

    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public UsersController(UserManager<ApplicationUser> userManager, IMapper _mapper) 
        {
            this.userManager = userManager;
            this.mapper = _mapper;
        }    
        public IActionResult Index()
        {
            var users = userManager.Users;
            var model = mapper.Map<IEnumerable<ApplicationUserVm>>(users);
           

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            var model = mapper.Map<ApplicationUserVm>(user);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUserVm UserVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await EditUser(UserVm);
                }
                else
                {
                    ModelState.AddModelError("", "Error ");
                    var user = await userManager.FindByIdAsync(UserVm.Id);
                    var model = mapper.Map<ApplicationUserVm>(user);

                    return View(model);
                }

            }
            catch(Exception ex)
            {
                var user = await userManager.FindByIdAsync(UserVm.Id);
                var model = mapper.Map<ApplicationUserVm>(user);

                return View(model);

            }
        }
        private async Task<IActionResult> EditUser(ApplicationUserVm UserVm)
        {
            ApplicationUser model = await userManager.FindByIdAsync(UserVm.Id);
            string FolderPath = "/wwwroot/Files/UsersImages";

            if (UserVm.Photo != null)
            {
                
                string fileName=FileUploader.UploadFile(FolderPath, UserVm.Photo);
                model.PhotoName = fileName;

            }
            else
            {
                if( UserVm.PhotoName == null|| UserVm.PhotoName == "")
                {
                     FileUploader.RemoveFile(FolderPath, model.PhotoName);
                     model.PhotoName = null;
                }
               
            }
            model.UserName = UserVm.UserName;
            model.Email=UserVm.Email;

           

            var result = await userManager.UpdateAsync(model);
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
                return View(UserVm);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            var model = mapper.Map<ApplicationUserVm>(user);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ApplicationUserVm applicationUser)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    ApplicationUser user = await userManager.FindByIdAsync(applicationUser.Id);
                    string FolderPath = "/wwwroot/Files/UsersImages";
                    string PhotoName = user.PhotoName;
                    var result= await userManager.DeleteAsync(user);
                    if (result.Succeeded)
                    {
                        if (PhotoName != null || PhotoName != "")
                        {
                        FileUploader.RemoveFile(FolderPath, PhotoName);
                        }
                        return RedirectToAction("Index");
                    }
                    else
                    {               
                        return View(applicationUser);
                    }
                }
                else
                {
                return View(applicationUser);

                }

            }
            catch (Exception ex)
            {
                return View(applicationUser);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            var model = mapper.Map<ApplicationUserVm>(user);
            return View(model);
        }
    }
}
