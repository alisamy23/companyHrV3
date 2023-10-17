using company.BL.Model;
using company.DAL.Extend;
using Demo.BL.Helper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

namespace companyHR.Controllers
{
  

    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<ApplictionRoles> roleManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,RoleManager<ApplictionRoles> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }  
        
        
        
        #region Registration
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Registration(RegistrationVM registration) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser()
                    {
                        Email=registration.Email,
                        IsAgree=registration.IsAgree,
                        UserName=registration.Email

                    };
                var result=   await userManager.CreateAsync(user, registration.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                    else 
                    {
                        foreach(var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }

                    }
                }
                return View(registration);
            }
            catch
            {
                return View(registration);

            }
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login( )
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(loginVM login)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    ApplicationUser loginUser = await userManager.FindByEmailAsync(login.Email);
                    var result = await signInManager.PasswordSignInAsync(loginUser, login.Password, login.RememberMe, false);
                    if (result.Succeeded)
                    {
                       // var roles = await userManager.GetRolesAsync(loginUser);
                       //var rolesId=await roleManager.Roles.Where(o=>roles.Contains(o.Name));


                        IList<string> roles = await userManager.GetRolesAsync(loginUser);
                        List<string> rolesid = roleManager.Roles.Where(o => roles.Contains(o.Name)).Select(o => o.Id).ToList();



                        var identity = new ClaimsIdentity(new[]

                        {
                            new Claim(ClaimTypes.Name, loginUser.UserName),
                            new Claim(ClaimTypes.Role, rolesid.FirstOrDefault()),
                        
                        }, "MyAuthType");
                        await HttpContext.SignInAsync(new ClaimsPrincipal(identity));
                        return RedirectToAction("index", "Home");
                    }
                    ModelState.AddModelError("", "Invalid User Name or Password");
                }
                    return View(login);               
            }
            catch
            {
            return View(login);

            }
        }
        #endregion

        #region Logoff

        public async Task < IActionResult> Logoff()
        {
            await signInManager.SignOutAsync(); 
            return RedirectToAction("Login");
        }

        #endregion

        #region ForgetPassword
        [HttpGet]
        public IActionResult ForgetPassword()
        {


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM forgetPassword)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(forgetPassword.Email);

                if (user != null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    var passwordResetLink = Url.Action("ResetPassword", "Account", new { Email = forgetPassword.Email, Token = token }, Request.Scheme);
                    string result = sendMail(forgetPassword, passwordResetLink);
                    if (result != "Faild")  return RedirectToAction("ConfirmForgetPassword");
                    else return View(forgetPassword);

                }
                else return View(forgetPassword);
            }
            catch
            {
                ModelState.AddModelError("", "Faild  to Send");
                return View(forgetPassword);
            }
        }

        private static string sendMail(ForgetPasswordVM forgetPassword, string? passwordResetLink)
        {
            return MailSender.SendMail(new Demo.BL.Models.MailVM()
            {
                Mail = forgetPassword.Email,
                Title = "Reset Password ",
                Message = passwordResetLink
            });
        }

        [HttpGet]
        public IActionResult ConfirmForgetPassword()
        {
            return View();
        }
        #endregion


        #region ResetPassword
        [HttpGet]
        public IActionResult ResetPassword(string Email ,string Token)
        {
            ResetPaswordVM forgetPassword = new ResetPaswordVM
            { 
            Email=Email,
            Token=Token 
            
            };
            return View(forgetPassword);
        }
        [HttpPost]
        public async Task< IActionResult> ResetPassword(ResetPaswordVM resetPasword)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByEmailAsync(resetPasword.Email);

                    if (user != null)
                    {
                        var result = await userManager.ResetPasswordAsync(user, resetPasword.Token, resetPasword.Password);

                        if (result.Succeeded)
                        {
                            return RedirectToAction("ConfirmResetPassword");
                        }

                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                        return View(resetPasword);
                    }

                    return RedirectToAction("ConfirmResetPassword");
                }
                return View(resetPasword);
            }
            catch
            {
                return View(resetPasword);

            }
        }
        public IActionResult ConfirmResetPassword()
        {
            return View();
        }
        #endregion


    }
}
