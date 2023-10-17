using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace companyHR.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
